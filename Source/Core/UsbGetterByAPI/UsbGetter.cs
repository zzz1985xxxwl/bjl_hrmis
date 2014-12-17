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
        /// 设备的各项属性，注意有些属性是不通用的，例如SPDRP_FRIENDLYNAME只适用于端口设备
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
        /// 销毁一个设备信息集合，并且释放所有关联的内存
        /// </summary>
        /// <param name="lpInfoSet">设备信息集合</param>
        /// <returns></returns>
        [DllImport("setupapi.dll", SetLastError = true)]
        private static extern bool SetupDiDestroyDeviceInfoList(IntPtr lpInfoSet);

        /// <summary>
        /// 获得该设备的设备范例ID
        /// </summary>
        /// <param name="DeviceInfoSet">设备信息集合</param>
        /// <param name="DeviceInfoData">表示该设备</param>
        /// <param name="DeviceInstanceId">设备范例ID（输出）</param>
        /// <param name="DeviceInstanceIdSize">该ID所占大小（字节）</param>
        /// <param name="RequiredSize">需要多少字节</param>
        /// <returns>是否成功</returns>
        [DllImport("setupapi.dll", SetLastError = true)]
        private static extern bool SetupDiGetDeviceInstanceId(IntPtr DeviceInfoSet,
                                                              ref SP_DEVINFO_DATA DeviceInfoData,
                                                              StringBuilder DeviceInstanceId,
                                                              UInt32 DeviceInstanceIdSize,
                                                              UInt32 RequiredSize);

        /// <summary>
        /// 枚举指定设备信息集合的成员，并将数据放在SP_DEVINFO_DATA中
        /// </summary>
        /// <param name="lpInfoSet">设备信息集合句柄</param>
        /// <param name="dwIndex">元素索引</param>
        /// <param name="devInfoData">表示一个设备（作为输出）</param>
        /// <returns>是否成功</returns>
        [DllImport("setupapi.dll", SetLastError = true)]
        private static extern bool SetupDiEnumDeviceInfo(IntPtr lpInfoSet, int dwIndex, ref SP_DEVINFO_DATA devInfoData);

        /// <summary>
        /// 获取指定设备的属性
        /// </summary>
        /// <param name="DeviceInfoSet">设备信息集合</param>
        /// <param name="DeviceInfoData">表示该设备</param>
        /// <param name="iProperty">表示要获取哪项属性</param>
        /// <param name="PropertyRegDataType">注册类型</param>
        /// <param name="PropertyBuffer">属性（输出）</param>
        /// <param name="PropertyBufferSize">存储属性的字节大小</param>
        /// <param name="RequiredSize">需要的字节大小</param>
        /// <returns>是否成功</returns>
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