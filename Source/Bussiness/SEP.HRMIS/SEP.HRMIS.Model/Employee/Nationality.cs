using System;

namespace SEP.HRMIS.Model
{
    /// <summary>
    /// ����
    /// </summary>
    [Serializable]
    public class Nationality : Parameter
    {
        /// <summary>
        /// ����
        /// </summary>
        /// <param name="parameterID"></param>
        /// <param name="name"></param>
        /// <param name="description"></param>
        public Nationality(int parameterID, string name, string description) : base(parameterID, name, description)
        {
        }
    }
}