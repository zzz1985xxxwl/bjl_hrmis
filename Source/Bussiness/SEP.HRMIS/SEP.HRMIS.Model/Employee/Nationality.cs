using System;

namespace SEP.HRMIS.Model
{
    /// <summary>
    /// ¹ú¼®
    /// </summary>
    [Serializable]
    public class Nationality : Parameter
    {
        /// <summary>
        /// ¹ú¼®
        /// </summary>
        /// <param name="parameterID"></param>
        /// <param name="name"></param>
        /// <param name="description"></param>
        public Nationality(int parameterID, string name, string description) : base(parameterID, name, description)
        {
        }
    }
}