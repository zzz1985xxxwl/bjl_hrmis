using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace UsbGetterByAPI
{
    [Guid("cb9da3eb-89d4-492c-a9eb-adf638f822ea")]
    public class UsbGetter
    {
        /// <summary>
        /// �豸�ĸ������ԣ�ע����Щ�����ǲ�ͨ�õģ�����SPDRP_FRIENDLYNAMEֻ�����ڶ˿��豸
        /// </summary>
        private enum SPDRP_
        {
            DEVICEDESC = (0x00000000), // DeviceDesc (R/W)
            //HARDWAREID = (0x00000001), // HardwareID (R/W)
            //SERVICE = (0x00000004), // Service (R/W)
            //CLASS = (0x00000007), // Class (R--tied to ClassGUID)
            //CLASSGUID = (0x00000008), // ClassGUID (R/W)
            //DRIVER = (0x00000009), // Driver (R/W)
            //CONFIGFLAGS = (0x0000000A), // ConfigFlags (R/W)
            //MFG = (0x0000000B), // Mfg (R/W)
            //FRIENDLYNAME = (0x0000000C), // FriendlyName (R/W)
            //PHYSICAL_DEVICE_OBJECT_NAME = (0x0000000E), // PhysicalDeviceObjectName (R)
            //CAPABILITIES = (0x0000000F), // Capabilities (R)
            //REMOVAL_POLICY_HW_DEFAULT = (0x00000020), // Hardware Removal Policy (R)
            //INSTALL_STATE = (0x00000022), // Device Install State (R)
        }

        private const int INVALID_HANDLE_VALUE = -1;
        private const int DIGCF_ALLCLASSES = 0x4;
        private const int DIGCF_PRESENT = 0x2;
        private const string REGSTR_KEY_USB = "USB";
        private const int BUFFER_SIZE = 2048;

        [StructLayout(LayoutKind.Sequential)]
        private struct SP_DEVINFO_DATA
        {
            public int cbSize;
            public Guid ClassGuid;
            public IntPtr DevInst;
            public int Reserved;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct SP_DEVICE_INTERFACE_DATA
        {
            public int cbSize;
            public Guid InterfaceClassGuid;
            public int Flags;
            public IntPtr Reserved;
        }

        /// <summary>
        /// ����һ���豸��Ϣ���ϣ������ͷ����й������ڴ�
        /// </summary>
        /// <param name="lpInfoSet">�豸��Ϣ����</param>
        /// <returns></returns>
        [DllImport("setupapi.dll", SetLastError = true)]
        private static extern bool SetupDiDestroyDeviceInfoList(IntPtr lpInfoSet);

        /// <summary>
        /// ��ø��豸���豸����ID
        /// </summary>
        /// <param name="DeviceInfoSet">�豸��Ϣ����</param>
        /// <param name="DeviceInfoData">��ʾ���豸</param>
        /// <param name="DeviceInstanceId">�豸����ID�������</param>
        /// <param name="DeviceInstanceIdSize">��ID��ռ��С���ֽڣ�</param>
        /// <param name="RequiredSize">��Ҫ�����ֽ�</param>
        /// <returns>�Ƿ�ɹ�</returns>
        [DllImport("setupapi.dll", SetLastError = true)]
        private static extern bool SetupDiGetDeviceInstanceId(IntPtr DeviceInfoSet,
                                                              ref SP_DEVINFO_DATA DeviceInfoData,
                                                              StringBuilder DeviceInstanceId,
                                                              UInt32 DeviceInstanceIdSize,
                                                              UInt32 RequiredSize);

        /// <summary>
        /// ö��ָ���豸��Ϣ���ϵĳ�Ա���������ݷ���SP_DEVINFO_DATA��
        /// </summary>
        /// <param name="lpInfoSet">�豸��Ϣ���Ͼ��</param>
        /// <param name="dwIndex">Ԫ������</param>
        /// <param name="devInfoData">��ʾһ���豸����Ϊ�����</param>
        /// <returns>�Ƿ�ɹ�</returns>
        [DllImport("setupapi.dll", SetLastError = true)]
        private static extern bool SetupDiEnumDeviceInfo(IntPtr lpInfoSet, int dwIndex, ref SP_DEVINFO_DATA devInfoData);

        /// <summary>
        /// ��ȡָ���豸������
        /// </summary>
        /// <param name="DeviceInfoSet">�豸��Ϣ����</param>
        /// <param name="DeviceInfoData">��ʾ���豸</param>
        /// <param name="iProperty">��ʾҪ��ȡ��������</param>
        /// <param name="PropertyRegDataType">ע������</param>
        /// <param name="PropertyBuffer">���ԣ������</param>
        /// <param name="PropertyBufferSize">�洢���Ե��ֽڴ�С</param>
        /// <param name="RequiredSize">��Ҫ���ֽڴ�С</param>
        /// <returns>�Ƿ�ɹ�</returns>
        [DllImport("setupapi.dll", SetLastError = true)]
        private static extern bool SetupDiGetDeviceRegistryProperty(IntPtr DeviceInfoSet,
                                                                    ref SP_DEVINFO_DATA DeviceInfoData, int iProperty,
                                                                    ref int PropertyRegDataType, IntPtr PropertyBuffer,
                                                                    int PropertyBufferSize, ref int RequiredSize);

        [DllImport("setupapi.dll", SetLastError = true)]
        private static extern IntPtr SetupDiGetClassDevs(ref int ClassGuid, string Enumerator, IntPtr hwndParent,
                                                         int Flags);

        [DllImport("setupapi.dll", SetLastError = true)]
        private static extern bool SetupDiGetDeviceInstanceId(IntPtr DeviceInfoSet, ref SP_DEVINFO_DATA DeviceInfoData,
                                                              StringBuilder DeviceInstanceId, int DeviceInstanceIdSize,
                                                              ref int RequiredSize);

        [DllImport("kernel32", SetLastError = true)]
        private static extern bool CloseHandle(IntPtr hObject);

        public int Count
        {
            get { return GetInstanceID().Count; }
        }

        public string Key
        {
            get
            {
                if (GetInstanceID().Count > 0)
                {
                    return GetInstanceID()[0].ToString();
                }
                return "";
            }
        }

        private static ArrayList GetInstanceID()
        {
            ArrayList ans =new ArrayList();
            int a = 0;
            IntPtr h = SetupDiGetClassDevs(ref a, REGSTR_KEY_USB, IntPtr.Zero, DIGCF_PRESENT | DIGCF_ALLCLASSES);
            if (h.ToInt32() != INVALID_HANDLE_VALUE)
            {
                IntPtr ptrBuf = Marshal.AllocHGlobal(BUFFER_SIZE);
                bool Success;
                int i = 0;
                do
                {
                    SP_DEVINFO_DATA da = new SP_DEVINFO_DATA();
                    da.cbSize = Marshal.SizeOf(da);
                    Success = SetupDiEnumDeviceInfo(h, i, ref da);
                    if (Success)
                    {
                        int RequiredSize = 0;
                        int RegType = 1;
                        string name;
                        if (
                            SetupDiGetDeviceRegistryProperty(h, ref da, (int)SPDRP_.DEVICEDESC, ref RegType, ptrBuf,
                                                             BUFFER_SIZE,
                                                             ref RequiredSize))
                        {
                            name = Marshal.PtrToStringAnsi(ptrBuf);
                            if (name.ToLower().Contains("usb mass storage device"))
                            {
                                int nBytes = 2048;
                                StringBuilder sb = new StringBuilder(nBytes);
                                SetupDiGetDeviceInstanceId(h, ref da, sb, nBytes, ref RequiredSize);
                                ans.Add(sb.ToString());
                            }
                        }
                    }
                    i++;
                } while (Success);
                CloseHandle(ptrBuf);
                SetupDiDestroyDeviceInfoList(h);
            }
            return ans;
        }
    }
}