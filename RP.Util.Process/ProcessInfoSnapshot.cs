using System;

namespace RP.Util.Process
{
    using System.ComponentModel;
    using System.Diagnostics;

    using RP.Util.Exception;

    public class ProcessInfoSnapshot
    {
        private void ProcessInfoSnapshot()
        {

        }

        public static ProcessInfoSnapshot TakeSnapshot(Process toSnapshot)
        {
            // Get a timestamp for the start of the snapshot - Stopwatch.GetTimestamp() is more accurate that DateTime.Now
            var snapshotStart = Stopwatch.GetTimestamp();

            // Do not produce a snapshot if the process has fininshed
            if (toSnapshot.HasExited) throw new InvalidOperationException("Process has exited");

            // Get the variables from the process object being snapshotted and if the operation throws an exception, capture i.
            var basePriority = Try.To(() => toSnapshot.BasePriority);
            var id = Try.To(() => toSnapshot.Id);
            var machineName = Try.To(() => toSnapshot.MachineName);
            var mainModule = Try.To(() => toSnapshot.MainModule);
            var mainWindowHandle = Try.To(() => toSnapshot.MainWindowHandle);
            var mainWindowTitle = Try.To(() => toSnapshot.MainWindowTitle);
            var maxWorkingSet = Try.To(() => toSnapshot.MaxWorkingSet);
            var handleCount = Try.To(() => toSnapshot.HandleCount);
            var handle = Try.To(() => toSnapshot.Handle);
            var minWorkingSet = Try.To(() => toSnapshot.MinWorkingSet);
            var modules = Try.To(() => toSnapshot.Modules);
            var nonpagedSystemMemorySize64 = Try.To(() => toSnapshot.NonpagedSystemMemorySize64);
            var pagedMemorySize64 = Try.To(() => toSnapshot.PagedSystemMemorySize64);
            var pagedSystemMemorySize64 = Try.To(() => toSnapshot.PagedSystemMemorySize64);
            var peakPagedMemorySize64 = Try.To(() => toSnapshot.PeakPagedMemorySize64);
            var peakVirtualMemorySize64 = Try.To(() => toSnapshot.PeakVirtualMemorySize64);
            var peakWorkingSet64 = Try.To(() => toSnapshot.PeakWorkingSet64);
            var priorityBoostEnabled = Try.To(() => toSnapshot.PriorityBoostEnabled);
            var priorityClass = Try.To(() => toSnapshot.PriorityClass);
            var privateMemorySize64 = Try.To(() => toSnapshot.PrivateMemorySize64);
            var privilegedProcessorTime = Try.To(() => toSnapshot.PrivilegedProcessorTime);
            var processName = Try.To(() => toSnapshot.ProcessName);
            var processorAffinity = Try.To(() => toSnapshot.ProcessorAffinity);
            var responding = Try.To(() => toSnapshot.Responding);
            var sessionId = Try.To(() => toSnapshot.SessionId);
            var startInfo = Try.To(() => toSnapshot.StartInfo);
            var startTime = Try.To(() => toSnapshot.StartTime);
            var synchronizingObject = Try.To(() => toSnapshot.SynchronizingObject);
            var threads = Try.To(() => toSnapshot.Threads);
            var totalProcessorTime = Try.To(() => toSnapshot.TotalProcessorTime);
            var userProcessorTime = Try.To(() => toSnapshot.UserProcessorTime);
            var virtualMemorySize64 = Try.To(() => toSnapshot.VirtualMemorySize64);
            var workingSet64 = Try.To(() => toSnapshot.WorkingSet64);

            // Get the time that the snapshot completed - Stopwatch.GetTimestamp() is more accurate that DateTime.Now
            var snapshotEnd = Stopwatch.GetTimestamp();

            // Create the snapshot object and return it
            var snapshot = new ProcessInfoSnapshot
            {
                BasePriority = basePriority,
                Id = id,
                MachineName = machineName,
                MainModule = mainModule,
                MainWindowHandle = mainWindowHandle,
                MainWindowTitle = mainWindowTitle,
                MaxWorkingSet = maxWorkingSet,
                HandleCount = handleCount,
                Handle = handle,
                MinWorkingSet = minWorkingSet,
                Modules = modules,
                NonpagedSystemMemorySize64 = nonpagedSystemMemorySize64,
                PagedMemorySize64 = pagedMemorySize64,
                PagedSystemMemorySize64 = pagedSystemMemorySize64,
                PeakPagedMemorySize64 = peakPagedMemorySize64,
                PeakVirtualMemorySize64 = peakVirtualMemorySize64,
                PeakWorkingSet64 = peakWorkingSet64,
                PriorityBoostEnabled = priorityBoostEnabled,
                PriorityClass = priorityClass,
                PrivateMemorySize64 = privateMemorySize64,
                PrivilegedProcessorTime = privilegedProcessorTime,
                ProcessName = processName,
                ProcessorAffinity = processorAffinity,
                Responding = responding,
                SessionId = sessionId,
                StartInfo = startInfo,
                StartTime = startTime,
                SynchronizingObject = synchronizingObject,
                Threads = threads,
                TotalProcessorTime = totalProcessorTime,
                UserProcessorTime = userProcessorTime,
                VirtualMemorySize64 = virtualMemorySize64,
                WorkingSet64 = workingSet64,
                SnapshotStart = new DateTime(snapshotStart),
                SnapshotEnd = new DateTime(snapshotEnd)
            };

            return snapshot;
        }

        /// <summary>
        /// Gets the base priority of the associated process.
        /// </summary>
        /// 
        /// <returns>
        /// The base priority, which is computed from the <see cref="P:System.Diagnostics.Process.PriorityClass"/> of the associated process.
        /// </returns>
        /// <exception cref="T:System.PlatformNotSupportedException">The platform is Windows 98 or Windows Millennium Edition (Windows Me); set the <see cref="P:System.Diagnostics.ProcessStartInfo.UseShellExecute"/> property to false to access this property on Windows 98 and Windows Me.</exception><exception cref="T:System.InvalidOperationException">The process has exited.-or- The process has not started, so there is no process ID. </exception><filterpriority>2</filterpriority>
        public ExceptionableResult<int> BasePriority { get; private set; }

        /// <summary>
        /// Gets the native handle of the associated process.
        /// </summary>
        /// 
        /// <returns>
        /// The handle that the operating system assigned to the associated process when the process was started. The system uses this handle to keep track of process attributes.
        /// </returns>
        /// <exception cref="T:System.InvalidOperationException">The process has not been started or has exited. The <see cref="P:System.Diagnostics.Process.Handle"/> property cannot be read because there is no process associated with this <see cref="T:System.Diagnostics.Process"/> instance.-or- The <see cref="T:System.Diagnostics.Process"/> instance has been attached to a running process but you do not have the necessary permissions to get a handle with full access rights. </exception><exception cref="T:System.NotSupportedException">You are trying to access the <see cref="P:System.Diagnostics.Process.Handle"/> property for a process that is running on a remote computer. This property is available only for processes that are running on the local computer.</exception><filterpriority>1</filterpriority>
        public ExceptionableResult<IntPtr> Handle { get; private set; }

        /// <summary>
        /// Gets the number of handles opened by the process.
        /// </summary>
        /// 
        /// <returns>
        /// The number of operating system handles the process has opened.
        /// </returns>
        /// <exception cref="T:System.PlatformNotSupportedException">The platform is Windows 98 or Windows Millennium Edition (Windows Me); set the <see cref="P:System.Diagnostics.ProcessStartInfo.UseShellExecute"/> property to false to access this property on Windows 98 and Windows Me.</exception><filterpriority>2</filterpriority>
        public ExceptionableResult<int> HandleCount { get; private set; }

        /// <summary>
        /// Gets the unique identifier for the associated process.
        /// </summary>
        /// 
        /// <returns>
        /// The system-generated unique identifier of the process that is referenced by this <see cref="T:System.Diagnostics.Process"/> instance.
        /// </returns>
        /// <exception cref="T:System.InvalidOperationException">The process's <see cref="P:System.Diagnostics.Process.Id"/> property has not been set.-or- There is no process associated with this <see cref="T:System.Diagnostics.Process"/> object. </exception><exception cref="T:System.PlatformNotSupportedException">The platform is Windows 98 or Windows Millennium Edition (Windows Me); set the <see cref="P:System.Diagnostics.ProcessStartInfo.UseShellExecute"/> property to false to access this property on Windows 98 and Windows Me.</exception><filterpriority>1</filterpriority>
        public ExceptionableResult<int> Id { get; private set; }

        /// <summary>
        /// Gets the name of the computer the associated process is running on.
        /// </summary>
        /// 
        /// <returns>
        /// The name of the computer that the associated process is running on.
        /// </returns>
        /// <exception cref="T:System.InvalidOperationException">There is no process associated with this <see cref="T:System.Diagnostics.Process"/> object. </exception>
        public ExceptionableResult<string> MachineName { get; private set; }

        /// <summary>
        /// Gets the window handle of the main window of the associated process.
        /// </summary>
        /// 
        /// <returns>
        /// The system-generated window handle of the main window of the associated process.
        /// </returns>
        /// <exception cref="T:System.InvalidOperationException">The <see cref="P:System.Diagnostics.Process.MainWindowHandle"/> is not defined because the process has exited. </exception><exception cref="T:System.NotSupportedException">You are trying to access the <see cref="P:System.Diagnostics.Process.MainWindowHandle"/> property for a process that is running on a remote computer. This property is available only for processes that are running on the local computer.</exception><exception cref="T:System.PlatformNotSupportedException">The platform is Windows 98 or Windows Millennium Edition (Windows Me); set <see cref="P:System.Diagnostics.ProcessStartInfo.UseShellExecute"/> to false to access this property on Windows 98 and Windows Me.</exception><filterpriority>2</filterpriority>
        public ExceptionableResult<IntPtr> MainWindowHandle { get; private set; }

        /// <summary>
        /// Gets the caption of the main window of the process.
        /// </summary>
        /// 
        /// <returns>
        /// The main window title of the process.
        /// </returns>
        /// <exception cref="T:System.InvalidOperationException">The <see cref="P:System.Diagnostics.Process.MainWindowTitle"/> property is not defined because the process has exited. </exception><exception cref="T:System.NotSupportedException">You are trying to access the <see cref="P:System.Diagnostics.Process.MainWindowTitle"/> property for a process that is running on a remote computer. This property is available only for processes that are running on the local computer.</exception><exception cref="T:System.PlatformNotSupportedException">The platform is Windows 98 or Windows Millennium Edition (Windows Me); set <see cref="P:System.Diagnostics.ProcessStartInfo.UseShellExecute"/> to false to access this property on Windows 98 and Windows Me.</exception><filterpriority>1</filterpriority>
        public ExceptionableResult<string> MainWindowTitle { get; private set; }

        /// <summary>
        /// Gets the main module for the associated process.
        /// </summary>
        /// 
        /// <returns>
        /// The <see cref="T:System.Diagnostics.ProcessModule"/> that was used to start the process.
        /// </returns>
        /// <exception cref="T:System.NotSupportedException">You are trying to access the <see cref="P:System.Diagnostics.Process.MainModule"/> property for a process that is running on a remote computer. This property is available only for processes that are running on the local computer.</exception><exception cref="T:System.ComponentModel.Win32Exception">A 32-bit process is trying to access the modules of a 64-bit process.</exception><exception cref="T:System.PlatformNotSupportedException">The platform is Windows 98 or Windows Millennium Edition (Windows Me); set <see cref="P:System.Diagnostics.ProcessStartInfo.UseShellExecute"/> to false to access this property on Windows 98 and Windows Me.</exception><exception cref="T:System.InvalidOperationException">The process <see cref="P:System.Diagnostics.Process.Id"/> is not available.-or- The process has exited. </exception><filterpriority>1</filterpriority>
        public ExceptionableResult<ProcessModule> MainModule { get; private set; }

        /// <summary>
        /// Gets or sets the maximum allowable working set size for the associated process.
        /// </summary>
        /// 
        /// <returns>
        /// The maximum working set size that is allowed in memory for the process, in bytes.
        /// </returns>
        /// <exception cref="T:System.ArgumentException">The maximum working set size is invalid. It must be greater than or equal to the minimum working set size.</exception>
        /// <exception cref="T:System.ComponentModel.Win32Exception">Working set information cannot be retrieved from the associated process resource.-or- The process identifier or process handle is zero because the process has not been started. </exception>
        /// <exception cref="T:System.NotSupportedException">You are trying to access the <see cref="P:System.Diagnostics.Process.MaxWorkingSet"/> property for a process that is running on a remote computer. This property is available only for processes that are running on the local computer.</exception>
        /// <exception cref="T:System.InvalidOperationException">The process <see cref="P:System.Diagnostics.Process.Id"/> is not available.-or- The process has exited. </exception>
        /// <exception cref="T:System.PlatformNotSupportedException">The platform is Windows 98 or Windows Millennium Edition (Windows Me), which does not support this property. </exception>
        public ExceptionableResult<IntPtr> MaxWorkingSet { get; private set; }

        /// <summary>
        /// Gets or sets the minimum allowable working set size for the associated process.
        /// </summary>
        /// 
        /// <returns>
        /// The minimum working set size that is required in memory for the process, in bytes.
        /// </returns>
        /// <exception cref="T:System.ArgumentException">The minimum working set size is invalid. It must be less than or equal to the maximum working set size.</exception>
        /// <exception cref="T:System.ComponentModel.Win32Exception">Working set information cannot be retrieved from the associated process resource.-or- The process identifier or process handle is zero because the process has not been started. </exception>
        /// <exception cref="T:System.NotSupportedException">You are trying to access the <see cref="P:System.Diagnostics.Process.MinWorkingSet"/> property for a process that is running on a remote computer. This property is available only for processes that are running on the local computer. </exception>
        /// <exception cref="T:System.InvalidOperationException">The process <see cref="P:System.Diagnostics.Process.Id"/> is not available.-or- The process has exited.</exception>
        /// <exception cref="T:System.PlatformNotSupportedException">The platform is Windows 98 or Windows Millennium Edition (Windows Me), which does not support this property. </exception>
        public ExceptionableResult<IntPtr> MinWorkingSet { get; private set; }

        /// <summary>
        /// Gets the modules that have been loaded by the associated process.
        /// </summary>
        /// 
        /// <returns>
        /// An array of type <see cref="T:System.Diagnostics.ProcessModule"/> that represents the modules that have been loaded by the associated process.
        /// </returns>
        /// <exception cref="T:System.NotSupportedException">You are attempting to access the <see cref="P:System.Diagnostics.Process.Modules"/> property for a process that is running on a remote computer. This property is available only for processes that are running on the local computer. </exception><exception cref="T:System.InvalidOperationException">The process <see cref="P:System.Diagnostics.Process.Id"/> is not available.</exception><exception cref="T:System.PlatformNotSupportedException">The platform is Windows 98 or Windows Millennium Edition (Windows Me); set <see cref="P:System.Diagnostics.ProcessStartInfo.UseShellExecute"/> to false to access this property on Windows 98 and Windows Me.</exception><exception cref="T:System.ComponentModel.Win32Exception">You are attempting to access the <see cref="P:System.Diagnostics.Process.Modules"/> property for either the system process or the idle process. These processes do not have modules.</exception><filterpriority>2</filterpriority>
        public ExceptionableResult<ProcessModuleCollection> Modules { get; private set; }

        /// <summary>
        /// Gets the amount of nonpaged system memory allocated for the associated process.
        /// </summary>
        /// 
        /// <returns>
        /// The amount of system memory, in bytes, allocated for the associated process that cannot be written to the virtual memory paging file.
        /// </returns>
        /// <exception cref="T:System.PlatformNotSupportedException">The platform is Windows 98 or Windows Millennium Edition (Windows Me), which does not support this property.</exception>
        public ExceptionableResult<long> NonpagedSystemMemorySize64 { get; private set; }

        /// <summary>
        /// Gets the amount of paged memory allocated for the associated process.
        /// </summary>
        /// 
        /// <returns>
        /// The amount of memory, in bytes, allocated in the virtual memory paging file for the associated process.
        /// </returns>
        /// <exception cref="T:System.PlatformNotSupportedException">The platform is Windows 98 or Windows Millennium Edition (Windows Me), which does not support this property.</exception>
        public ExceptionableResult<long> PagedMemorySize64 { get; private set; }

        /// <summary>
        /// Gets the amount of pageable system memory allocated for the associated process.
        /// </summary>
        /// 
        /// <returns>
        /// The amount of system memory, in bytes, allocated for the associated process that can be written to the virtual memory paging file.
        /// </returns>
        /// <exception cref="T:System.PlatformNotSupportedException">The platform is Windows 98 or Windows Millennium Edition (Windows Me), which does not support this property.</exception>
        public ExceptionableResult<long> PagedSystemMemorySize64 { get; private set; }

        /// <summary>
        /// Gets the maximum amount of memory in the virtual memory paging file used by the associated process.
        /// </summary>
        /// 
        /// <returns>
        /// The maximum amount of memory, in bytes, allocated in the virtual memory paging file for the associated process since it was started.
        /// </returns>
        /// <exception cref="T:System.PlatformNotSupportedException">The platform is Windows 98 or Windows Millennium Edition (Windows Me), which does not support this property.</exception>
        public ExceptionableResult<long> PeakPagedMemorySize64 { get; private set; }

        /// <summary>
        /// Gets the maximum amount of physical memory used by the associated process.
        /// </summary>
        /// 
        /// <returns>
        /// The maximum amount of physical memory, in bytes, allocated for the associated process since it was started.
        /// </returns>
        /// <exception cref="T:System.PlatformNotSupportedException">The platform is Windows 98 or Windows Millennium Edition (Windows Me), which does not support this property.</exception>
        public ExceptionableResult<long> PeakWorkingSet64 { get; private set; }

        /// <summary>
        /// Gets the maximum amount of virtual memory used by the associated process.
        /// </summary>
        /// 
        /// <returns>
        /// The maximum amount of virtual memory, in bytes, allocated for the associated process since it was started.
        /// </returns>
        /// <exception cref="T:System.PlatformNotSupportedException">The platform is Windows 98 or Windows Millennium Edition (Windows Me), which does not support this property.</exception>
        public ExceptionableResult<long> PeakVirtualMemorySize64 { get; private set; }

        /// <summary>
        /// Gets or sets a value indicating whether the associated process priority should temporarily be boosted by the operating system when the main window has the focus.
        /// </summary>
        /// 
        /// <returns>
        /// true if dynamic boosting of the process priority should take place for a process when it is taken out of the wait state; otherwise, false. The default is false.
        /// </returns>
        /// <exception cref="T:System.ComponentModel.Win32Exception">Priority boost information could not be retrieved from the associated process resource. </exception><exception cref="T:System.PlatformNotSupportedException">The platform is Windows 98 or Windows Millennium Edition (Windows Me), which does not support this property.-or- The process identifier or process handle is zero. (The process has not been started.) </exception><exception cref="T:System.NotSupportedException">You are attempting to access the <see cref="P:System.Diagnostics.Process.PriorityBoostEnabled"/> property for a process that is running on a remote computer. This property is available only for processes that are running on the local computer. </exception><exception cref="T:System.InvalidOperationException">The process <see cref="P:System.Diagnostics.Process.Id"/> is not available.</exception><filterpriority>1</filterpriority>
        public ExceptionableResult<bool> PriorityBoostEnabled { get; private set; }

        /// <summary>
        /// Gets or sets the overall priority category for the associated process.
        /// </summary>
        /// 
        /// <returns>
        /// The priority category for the associated process, from which the <see cref="P:System.Diagnostics.Process.BasePriority"/> of the process is calculated.
        /// </returns>
        /// <exception cref="T:System.ComponentModel.Win32Exception">Process priority information could not be set or retrieved from the associated process resource.-or- The process identifier or process handle is zero. (The process has not been started.) </exception><exception cref="T:System.NotSupportedException">You are attempting to access the <see cref="P:System.Diagnostics.Process.PriorityClass"/> property for a process that is running on a remote computer. This property is available only for processes that are running on the local computer. </exception><exception cref="T:System.InvalidOperationException">The process <see cref="P:System.Diagnostics.Process.Id"/> is not available.</exception><exception cref="T:System.PlatformNotSupportedException">You have set the <see cref="P:System.Diagnostics.Process.PriorityClass"/> to AboveNormal or BelowNormal when using Windows 98 or Windows Millennium Edition (Windows Me). These platforms do not support those values for the priority class. </exception><exception cref="T:System.ComponentModel.InvalidEnumArgumentException">Priority class cannot be set because it does not use a valid value, as defined in the <see cref="T:System.Diagnostics.ProcessPriorityClass"/> enumeration.</exception><filterpriority>1</filterpriority>
        public ExceptionableResult<ProcessPriorityClass> PriorityClass { get; private set; }

        /// <summary>
        /// Gets the amount of private memory allocated for the associated process.
        /// </summary>
        /// 
        /// <returns>
        /// The amount of memory, in bytes, allocated for the associated process that cannot be shared with other processes.
        /// </returns>
        /// <exception cref="T:System.PlatformNotSupportedException">The platform is Windows 98 or Windows Millennium Edition (Windows Me), which does not support this property.</exception>
        public ExceptionableResult<long> PrivateMemorySize64 { get; private set; }

        /// <summary>
        /// Gets the privileged processor time for this process.
        /// </summary>
        /// 
        /// <returns>
        /// A <see cref="T:System.TimeSpan"/> that indicates the amount of time that the process has spent running code inside the operating system core.
        /// </returns>
        /// <exception cref="T:System.PlatformNotSupportedException">The platform is Windows 98 or Windows Millennium Edition (Windows Me), which does not support this property. </exception><exception cref="T:System.NotSupportedException">You are attempting to access the <see cref="P:System.Diagnostics.Process.PrivilegedProcessorTime"/> property for a process that is running on a remote computer. This property is available only for processes that are running on the local computer. </exception><filterpriority>2</filterpriority>
        public ExceptionableResult<TimeSpan> PrivilegedProcessorTime { get; private set; }

        /// <summary>
        /// Gets the name of the process.
        /// </summary>
        /// 
        /// <returns>
        /// The name that the system uses to identify the process to the user.
        /// </returns>
        /// <exception cref="T:System.InvalidOperationException">The process does not have an identifier, or no process is associated with the <see cref="T:System.Diagnostics.Process"/>.-or- The associated process has exited. </exception><exception cref="T:System.PlatformNotSupportedException">The platform is Windows 98 or Windows Millennium Edition (Windows Me); set <see cref="P:System.Diagnostics.ProcessStartInfo.UseShellExecute"/> to false to access this property on Windows 98 and Windows Me.</exception><exception cref="T:System.NotSupportedException">The process is not on this computer.</exception><filterpriority>1</filterpriority>
        public ExceptionableResult<string> ProcessName { get; private set; }

        /// <summary>
        /// Gets or sets the processors on which the threads in this process can be scheduled to run.
        /// </summary>
        /// 
        /// <returns>
        /// A bitmask representing the processors that the threads in the associated process can run on. The default depends on the number of processors on the computer. The default value is 2 n -1, where n is the number of processors.
        /// </returns>
        /// <exception cref="T:System.ComponentModel.Win32Exception"><see cref="P:System.Diagnostics.Process.ProcessorAffinity"/> information could not be set or retrieved from the associated process resource.-or- The process identifier or process handle is zero. (The process has not been started.) </exception><exception cref="T:System.NotSupportedException">You are attempting to access the <see cref="P:System.Diagnostics.Process.ProcessorAffinity"/> property for a process that is running on a remote computer. This property is available only for processes that are running on the local computer. </exception><exception cref="T:System.InvalidOperationException">The process <see cref="P:System.Diagnostics.Process.Id"/> was not available.-or- The process has exited. </exception><filterpriority>2</filterpriority>
        public ExceptionableResult<IntPtr> ProcessorAffinity { get; private set; }

        /// <summary>
        /// Gets a value indicating whether the user interface of the process is responding.
        /// </summary>
        /// 
        /// <returns>
        /// true if the user interface of the associated process is responding to the system; otherwise, false.
        /// </returns>
        /// <exception cref="T:System.PlatformNotSupportedException">The platform is Windows 98 or Windows Millennium Edition (Windows Me); set <see cref="P:System.Diagnostics.ProcessStartInfo.UseShellExecute"/> to false to access this property on Windows 98 and Windows Me.</exception>
        /// <exception cref="T:System.InvalidOperationException">There is no process associated with this <see cref="T:System.Diagnostics.Process"/> object. </exception>
        /// <exception cref="T:System.NotSupportedException">You are attempting to access the <see cref="P:System.Diagnostics.Process.Responding"/> property for a process that is running on a remote computer. This property is available only for processes that are running on the local computer. </exception>
        public ExceptionableResult<bool> Responding { get; private set; }

        /// <summary>
        /// Gets the Terminal Services session identifier for the associated process.
        /// </summary>
        /// 
        /// <returns>
        /// The Terminal Services session identifier for the associated process.
        /// </returns>
        /// <exception cref="T:System.NullReferenceException">There is no session associated with this process.</exception><exception cref="T:System.InvalidOperationException">There is no process associated with this session identifier.-or-The associated process is not on this machine. </exception><exception cref="T:System.PlatformNotSupportedException">The <see cref="P:System.Diagnostics.Process.SessionId"/> property is not supported on Windows 98.</exception><filterpriority>1</filterpriority>
        public ExceptionableResult<int> SessionId { get; private set; }

        /// <summary>
        /// Gets or sets the properties to pass to the <see cref="M:System.Diagnostics.Process.Start"/> method of the <see cref="T:System.Diagnostics.Process"/>.
        /// </summary>
        /// 
        /// <returns>
        /// The <see cref="T:System.Diagnostics.ProcessStartInfo"/> that represents the data with which to start the process. These arguments include the name of the executable file or document used to start the process.
        /// </returns>
        /// <exception cref="T:System.ArgumentNullException">The value that specifies the <see cref="P:System.Diagnostics.Process.StartInfo"/> is null. </exception>
        public ExceptionableResult<ProcessStartInfo> StartInfo { get; private set; }

        /// <summary>
        /// Gets the time that the associated process was started.
        /// </summary>
        /// 
        /// <returns>
        /// A <see cref="T:System.DateTime"/> that indicates when the process started. This only has meaning for started processes.
        /// </returns>
        /// <exception cref="T:System.PlatformNotSupportedException">The platform is Windows 98 or Windows Millennium Edition (Windows Me), which does not support this property. </exception><exception cref="T:System.NotSupportedException">You are attempting to access the <see cref="P:System.Diagnostics.Process.StartTime"/> property for a process that is running on a remote computer. This property is available only for processes that are running on the local computer. </exception><exception cref="T:System.InvalidOperationException">The process has exited.</exception><exception cref="T:System.ComponentModel.Win32Exception">An error occurred in the call to the Windows function.</exception><filterpriority>1</filterpriority>
        public ExceptionableResult<DateTime> StartTime { get; private set; }

        /// <summary>
        /// Gets or sets the object used to marshal the event handler calls that are issued as a result of a process exit event.
        /// </summary>
        /// 
        /// <returns>
        /// The <see cref="T:System.ComponentModel.ISynchronizeInvoke"/> used to marshal event handler calls that are issued as a result of an <see cref="E:System.Diagnostics.Process.Exited"/> event on the process.
        /// </returns>
        /// <filterpriority>2</filterpriority>
        public ExceptionableResult<ISynchronizeInvoke> SynchronizingObject { get; private set; }

        /// <summary>
        /// Gets the set of threads that are running in the associated process.
        /// </summary>
        /// 
        /// <returns>
        /// An array of type <see cref="T:System.Diagnostics.ProcessThread"/> representing the operating system threads currently running in the associated process.
        /// </returns>
        /// <exception cref="T:System.SystemException">The process does not have an <see cref="P:System.Diagnostics.Process.Id"/>, or no process is associated with the <see cref="T:System.Diagnostics.Process"/> instance.-or- The associated process has exited. </exception><exception cref="T:System.PlatformNotSupportedException">The platform is Windows 98 or Windows Millennium Edition (Windows Me); set <see cref="P:System.Diagnostics.ProcessStartInfo.UseShellExecute"/> to false to access this property on Windows 98 and Windows Me.</exception><filterpriority>1</filterpriority>
        public ExceptionableResult<ProcessThreadCollection> Threads { get; private set; }

        /// <summary>
        /// Gets the total processor time for this process.
        /// </summary>
        /// 
        /// <returns>
        /// A <see cref="T:System.TimeSpan"/> that indicates the amount of time that the associated process has spent utilizing the CPU. This value is the sum of the <see cref="P:System.Diagnostics.Process.UserProcessorTime"/> and the <see cref="P:System.Diagnostics.Process.PrivilegedProcessorTime"/>.
        /// </returns>
        /// <exception cref="T:System.PlatformNotSupportedException">The platform is Windows 98 or Windows Millennium Edition (Windows Me), which does not support this property. </exception><exception cref="T:System.NotSupportedException">You are attempting to access the <see cref="P:System.Diagnostics.Process.TotalProcessorTime"/> property for a process that is running on a remote computer. This property is available only for processes that are running on the local computer. </exception><filterpriority>2</filterpriority>
        public ExceptionableResult<TimeSpan> TotalProcessorTime { get; private set; }

        /// <summary>
        /// Gets the user processor time for this process.
        /// </summary>
        /// 
        /// <returns>
        /// A <see cref="T:System.TimeSpan"/> that indicates the amount of time that the associated process has spent running code inside the application portion of the process (not inside the operating system core).
        /// </returns>
        /// <exception cref="T:System.PlatformNotSupportedException">The platform is Windows 98 or Windows Millennium Edition (Windows Me), which does not support this property. </exception><exception cref="T:System.NotSupportedException">You are attempting to access the <see cref="P:System.Diagnostics.Process.UserProcessorTime"/> property for a process that is running on a remote computer. This property is available only for processes that are running on the local computer. </exception><filterpriority>2</filterpriority>
        public ExceptionableResult<TimeSpan> UserProcessorTime { get; private set; }

        /// <summary>
        /// Gets the amount of the virtual memory allocated for the associated process.
        /// </summary>
        /// 
        /// <returns>
        /// The amount of virtual memory, in bytes, allocated for the associated process.
        /// </returns>
        /// <exception cref="T:System.PlatformNotSupportedException">The platform is Windows 98 or Windows Millennium Edition (Windows Me), which does not support this property.</exception>
        public ExceptionableResult<long> VirtualMemorySize64 { get; private set; }


        /// <summary>
        /// Gets the amount of physical memory allocated for the associated process.
        /// </summary>
        /// 
        /// <returns>
        /// The amount of physical memory, in bytes, allocated for the associated process.
        /// </returns>
        /// <exception cref="T:System.PlatformNotSupportedException">The platform is Windows 98 or Windows Millennium Edition (Windows Me), which does not support this property.</exception>
        public ExceptionableResult<long> WorkingSet64 { get; private set; }

        /// <summary>
        /// The time that the snapshot was started
        /// </summary>
        public DateTime SnapshotStart { get; set; }

        /// <summary>
        /// The time that the snapshot was completed
        /// </summary>
        public DateTime SnapshotEnd { get; set; }
    }
}
