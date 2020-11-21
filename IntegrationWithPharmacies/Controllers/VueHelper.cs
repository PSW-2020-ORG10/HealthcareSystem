using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.SpaServices;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace IntegrationWithPharmacies.Controllers
{
    public static class VueHelper
    { 
        private static int Port { get; } = 8081;
        private static Uri DevelopmentServerEndpoint { get; } = new Uri($"http://localhost:{Port}");
        private static TimeSpan Timeout { get; } = TimeSpan.FromSeconds(30);
 
        private static string DoneMessage { get; } = "DONE  Compiled successfully in";
        private static TaskCompletionSource<int> taskCompletionSource = new TaskCompletionSource<int>();

        public static void UseVueDevelopmentServer(this ISpaBuilder spaBuilder)
        {
            spaBuilder.UseProxyToSpaDevelopmentServer(async () =>
            {               
                if (IsRunning()) return DevelopmentServerEndpoint;
                
                _ = getRunnedTaskOutput(getProcess(),getLogger(spaBuilder), taskCompletionSource);

                _ = getRunnedTaskError(getProcess(), getLogger(spaBuilder), taskCompletionSource);

                if (await Task.WhenAny(Task.Delay(Timeout), taskCompletionSource.Task) == Task.Delay(Timeout)) throw new TimeoutException();
                
                return DevelopmentServerEndpoint;
            });
        }

        private static Process getProcess()
        {
            return Process.Start(getProcessInfo(RuntimeInformation.IsOSPlatform(OSPlatform.Windows)));
        }

        private static ILogger getLogger(ISpaBuilder spaBuilder)
        {
            return spaBuilder.ApplicationBuilder.ApplicationServices.GetService<ILoggerFactory>().CreateLogger("Vue");
        }

        private static object getRunnedTaskError(Process process, ILogger logger, TaskCompletionSource<int> taskCompletionSource)
        {
            return Task.Run(() =>
            {   try{
                    getStandardError(process,logger);
                }
                catch (EndOfStreamException exception) {
                    getException(logger, exception);
                }
            });
        }

        private static void getStandardError(Process process, ILogger logger)
        {
            string line;
            while ((line = process.StandardError.ReadLine()) != null) logger.LogError(line);
        }

        private static object getRunnedTaskOutput(Process process, ILogger logger, TaskCompletionSource<int> taskCompletionSource)
        {
            return Task.Run(() =>
            {   try {
                    getStandardOutput(process,logger);
                }
                catch (EndOfStreamException exception) {
                    getException(logger, exception);
                }
            });
        }

        private static void getStandardOutput(Process process, ILogger logger)
        {
            string line;
            while ((line = process.StandardOutput.ReadLine()) != null)
            {
                logger.LogInformation(line);
                if (!taskCompletionSource.Task.IsCompleted && line.Contains(DoneMessage)) taskCompletionSource.SetResult(1);
            }
        }

        private static void getException(ILogger logger, EndOfStreamException exception)
        {
            logger.LogError(exception.ToString());
            taskCompletionSource.SetException(new InvalidOperationException("'npm run serve' failed.", exception));
        }


        private static ProcessStartInfo getProcessInfo(bool isWindows)
        {
            return new ProcessStartInfo {
                FileName = isWindows ? "cmd" : "npm",
                Arguments = $"{(isWindows ? "/c npm " : "")}run serve",
                WorkingDirectory = "front",
                RedirectStandardError = true,
                RedirectStandardInput = true,
                RedirectStandardOutput = true,
                UseShellExecute = false,};
        }

        private static bool IsRunning() => IPGlobalProperties.GetIPGlobalProperties().GetActiveTcpListeners().Select(x => x.Port).Contains(Port);
    }
}
