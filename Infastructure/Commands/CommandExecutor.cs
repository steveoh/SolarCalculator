namespace SolarCalculator.Infastructure.Commands
{
    public class CommandExecutor
    {
        /// <summary>
        ///   Executes the command.
        /// </summary>
        /// <param name="cmd"> The CMD. </param>
        public static void ExecuteCommand(Command cmd)
        {
            cmd.Run();
        }

        /// <summary>
        ///   Executes the command for commands with a result.
        /// </summary>
        /// <typeparam name="TResult"> The type of the result. </typeparam>
        /// <param name="cmd"> The CMD. </param>
        /// <returns> </returns>
        public static TResult ExecuteCommand<TResult>(Command<TResult> cmd)
        {
            ExecuteCommand((Command) cmd);

            return cmd.Result;
        }
    }
}