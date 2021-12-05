using System.Reflection;

namespace Mediation
{
    public class MediationableObjectInfo
    {
        public object instance;
        public MethodInfo method;

        public MediationableObjectInfo(object instance, MethodInfo method)
        {
            this.instance = instance;
            this.method = method;
        }
    }
}