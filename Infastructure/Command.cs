using System;
using System.Diagnostics;
using ESRI.ArcGIS.SOESupport;
using SolarCalculator.Extensions;

namespace SolarCalculator.Infastructure
{
    /// <summary>
    /// A command with no return value
    /// </summary>
    public abstract class Command
    {
        /// <summary>
        /// The message code to be used for all failed commands
        /// </summary>
        private const int MessageCode = 8080;

        public void Run()
        {
            try
            {
                Debug.Print("Executing\r\n{0}".With(ToString()));
                Execute();
                Debug.Print("Done Executing\r\n{0}".With(ToString()));
            }
            catch (Exception ex)
            {
                Debug.Print("Error processing task: {0}".With(ToString()), ex);
                SoeBase.Logger.LogMessage(ServerLogger.msgType.error, ToString(),MessageCode, ex.Message + " " + ex.InnerException);
            }
        }

        public abstract override string ToString();

        protected abstract void Execute();
    }

    /// <summary>
    /// A command with a return value
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class Command<T> : Command
    {
        public T Result { get; protected set; }

        public T GetResult()
        {
            Run();
            return Result;
        }
    }
}