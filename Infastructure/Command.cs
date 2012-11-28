using System;
using System.Diagnostics;
using ESRI.ArcGIS.SOESupport;
using SolarCalculator.Extensions;

namespace SolarCalculator.Infastructure
{
    /// <summary>
    ///   A command with no return value
    /// </summary>
    public abstract class Command
    {
        /// <summary>
        ///   The message code to be used for all failed commands
        /// </summary>
        internal const int MessageCode = 2472;

        internal ServerLogger Logger = new ServerLogger();

        public void Run()
        {
            var commandName = ToString();

            try
            {
                Debug.Print("Executing\r\n{0}".With(commandName));
                Logger.LogMessage(ServerLogger.msgType.debug, "{0}.{1}".With(commandName, "execute"), MessageCode,
                                  "Executing\r\n{0}".With(commandName));

                Execute();
                Debug.Print("Done Executing\r\n{0}".With(commandName));

                Logger.LogMessage(ServerLogger.msgType.debug, "{0}.{1}".With(commandName, "execute"), MessageCode,
                                  "Done Executing");
            }
            catch (Exception ex)
            {
                Debug.Print("Error processing task: {0}".With(commandName), ex);
                Logger.LogMessage(ServerLogger.msgType.error, "{0}.{1}".With(commandName, "execute"), MessageCode,
                                  "Error running command");
            }
            finally
            {
                Logger = null;
            }
        }

        public abstract override string ToString();

        /// <summary>
        ///   code to execute when command is run.
        /// </summary>
        protected abstract void Execute();
    }

    /// <summary>
    ///   A command with a return value
    /// </summary>
    /// <typeparam name="T"> </typeparam>
    public abstract class Command<T> : Command
    {
        public T Result { get; protected set; }

        public T GetResult()
        {
            Run();

            Logger = new ServerLogger();

            Logger.LogMessage(ServerLogger.msgType.debug, ToString(), MessageCode,
                              "Done Executing\r\n{0}\r\nResult: {1}".With(ToString(), Result));
            Logger = null;

            return Result;
        }
    }
}