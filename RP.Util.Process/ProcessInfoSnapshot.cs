namespace RP.Util.Process
{
    using System;

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
        public ExceptionableResult<int> BasePriority { get; private set; }

        /// <summary>
        /// Gets the number of handles opened by the process.
        /// </summary>
        /// 
        /// <returns>
        /// The number of operating system handles the process has opened.
        /// </returns>
        public ExceptionableResult<int> HandleCount { get; private set; }

        /// <summary>
        /// Gets the unique identifier for the associated process.
        /// </summary>
        /// 
        /// <returns>
        /// The system-generated unique identifier of the process that is referenced by this <see cref="T:System.Diagnostics.Process"/> instance.
        /// </returns>
        public ExceptionableResult<int> Id { get; private set; }

        /// <summary>
        /// Gets the name of the computer the associated process is running on.
        /// </summary>
        /// 
        /// <returns>
        /// The name of the computer that the associated process is running on.
        /// </returns>
        public ExceptionableResult<string> MachineName { get; private set; }

        /// <summary>
        /// Gets the window handle of the main window of the associated process.
        /// </summary>
        /// 
        /// <returns>
        /// The system-generated window handle of the main window of the associated process.
        /// </returns>
        public ExceptionableResult<IntPtr> MainWindowHandle { get; private set; }

        /// <summary>
        /// Gets the caption of the main window of the process.
        /// </summary>
        /// 
        /// <returns>
        /// The main window title of the process.
        /// </returns>
        public ExceptionableResult<string> MainWindowTitle { get; private set; }

        /// <summary>
        /// Gets the main module for the associated process.
        /// </summary>
        /// 
        /// <returns>
        /// The <see cref="T:System.Diagnostics.ProcessModule"/> that was used to start the process.
        /// </returns>
        public ExceptionableResult<ProcessModule> MainModule { get; private set; }

        /// <summary>
        /// Gets or sets the maximum allowable working set size for the associated process.
        /// </summary>
        /// 
        /// <returns>
        /// The maximum working set size that is allowed in memory for the process, in bytes.
        /// </returns>
        public ExceptionableResult<IntPtr> MaxWorkingSet { get; private set; }

        /// <summary>
        /// Gets or sets the minimum allowable working set size for the associated process.
        /// </summary>
        /// 
        /// <returns>
        /// The minimum working set size that is required in memory for the process, in bytes.
        /// </returns>
        public ExceptionableResult<IntPtr> MinWorkingSet { get; private set; }

        /// <summary>
        /// Gets the modules that have been loaded by the associated process.
        /// </summary>
        /// 
        /// <returns>
        /// An array of type <see cref="T:System.Diagnostics.ProcessModule"/> that represents the modules that have been loaded by the associated process.
        /// </returns>
        public ExceptionableResult<ProcessModuleCollection> Modules { get; private set; }

        /// <summary>
        /// Gets the amount of nonpaged system memory allocated for the associated process.
        /// </summary>
        /// 
        /// <returns>
        /// The amount of system memory, in bytes, allocated for the associated process that cannot be written to the virtual memory paging file.
        /// </returns>
        public ExceptionableResult<long> NonpagedSystemMemorySize64 { get; private set; }

        /// <summary>
        /// Gets the amount of paged memory allocated for the associated process.
        /// </summary>
        /// 
        /// <returns>
        /// The amount of memory, in bytes, allocated in the virtual memory paging file for the associated process.
        /// </returns>
        public ExceptionableResult<long> PagedMemorySize64 { get; private set; }

        /// <summary>
        /// Gets the amount of pageable system memory allocated for the associated process.
        /// </summary>
        /// 
        /// <returns>
        /// The amount of system memory, in bytes, allocated for the associated process that can be written to the virtual memory paging file.
        /// </returns>
        public ExceptionableResult<long> PagedSystemMemorySize64 { get; private set; }

        /// <summary>
        /// Gets the maximum amount of memory in the virtual memory paging file used by the associated process.
        /// </summary>
        /// 
        /// <returns>
        /// The maximum amount of memory, in bytes, allocated in the virtual memory paging file for the associated process since it was started.
        /// </returns>
        public ExceptionableResult<long> PeakPagedMemorySize64 { get; private set; }

        /// <summary>
        /// Gets the maximum amount of physical memory used by the associated process.
        /// </summary>
        /// 
        /// <returns>
        /// The maximum amount of physical memory, in bytes, allocated for the associated process since it was started.
        /// </returns>
        public ExceptionableResult<long> PeakWorkingSet64 { get; private set; }

        /// <summary>
        /// Gets the maximum amount of virtual memory used by the associated process.
        /// </summary>
        /// 
        /// <returns>
        /// The maximum amount of virtual memory, in bytes, allocated for the associated process since it was started.
        /// </returns>
        public ExceptionableResult<long> PeakVirtualMemorySize64 { get; private set; }

        /// <summary>
        /// Gets or sets a value indicating whether the associated process priority should temporarily be boosted by the operating system when the main window has the focus.
        /// </summary>
        /// 
        /// <returns>
        /// true if dynamic boosting of the process priority should take place for a process when it is taken out of the wait state; otherwise, false. The default is false.
        /// </returns>
        public ExceptionableResult<bool> PriorityBoostEnabled { get; private set; }

        /// <summary>
        /// Gets or sets the overall priority category for the associated process.
        /// </summary>
        /// 
        /// <returns>
        /// The priority category for the associated process, from which the <see cref="P:System.Diagnostics.Process.BasePriority"/> of the process is calculated.
        /// </returns>
        public ExceptionableResult<ProcessPriorityClass> PriorityClass { get; private set; }

        /// <summary>
        /// Gets the amount of private memory allocated for the associated process.
        /// </summary>
        /// 
        /// <returns>
        /// The amount of memory, in bytes, allocated for the associated process that cannot be shared with other processes.
        /// </returns>
        public ExceptionableResult<long> PrivateMemorySize64 { get; private set; }

        /// <summary>
        /// Gets the privileged processor time for this process.
        /// </summary>
        /// 
        /// <returns>
        /// A <see cref="T:System.TimeSpan"/> that indicates the amount of time that the process has spent running code inside the operating system core.
        /// </returns>
        public ExceptionableResult<TimeSpan> PrivilegedProcessorTime { get; private set; }

        /// <summary>
        /// Gets the name of the process.
        /// </summary>
        /// 
        /// <returns>
        /// The name that the system uses to identify the process to the user.
        /// </returns>
        public ExceptionableResult<string> ProcessName { get; private set; }

        /// <summary>
        /// Gets or sets the processors on which the threads in this process can be scheduled to run.
        /// </summary>
        /// 
        /// <returns>
        /// A bitmask representing the processors that the threads in the associated process can run on. The default depends on the number of processors on the computer. The default value is 2 n -1, where n is the number of processors.
        /// </returns>
        public ExceptionableResult<IntPtr> ProcessorAffinity { get; private set; }

        /// <summary>
        /// Gets a value indicating whether the user interface of the process is responding.
        /// </summary>
        /// 
        /// <returns>
        /// true if the user interface of the associated process is responding to the system; otherwise, false.
        /// </returns>
        public ExceptionableResult<bool> Responding { get; private set; }

        /// <summary>
        /// Gets the Terminal Services session identifier for the associated process.
        /// </summary>
        /// 
        /// <returns>
        /// The Terminal Services session identifier for the associated process.
        /// </returns>
        public ExceptionableResult<int> SessionId { get; private set; }

        /// <summary>
        /// Gets or sets the properties to pass to the <see cref="M:System.Diagnostics.Process.Start"/> method of the <see cref="T:System.Diagnostics.Process"/>.
        /// </summary>
        /// 
        /// <returns>
        /// The <see cref="T:System.Diagnostics.ProcessStartInfo"/> that represents the data with which to start the process. These arguments include the name of the executable file or document used to start the process.
        /// </returns>
        public ExceptionableResult<ProcessStartInfo> StartInfo { get; private set; }

        /// <summary>
        /// Gets the time that the associated process was started.
        /// </summary>
        /// 
        /// <returns>
        /// A <see cref="T:System.DateTime"/> that indicates when the process started. This only has meaning for started processes.
        /// </returns>
        public ExceptionableResult<DateTime> StartTime { get; private set; }

        /// <summary>
        /// Gets the set of threads that are running in the associated process.
        /// </summary>
        /// 
        /// <returns>
        /// An array of type <see cref="T:System.Diagnostics.ProcessThread"/> representing the operating system threads currently running in the associated process.
        /// </returns>
        public ExceptionableResult<ProcessThreadCollection> Threads { get; private set; }

        /// <summary>
        /// Gets the total processor time for this process.
        /// </summary>
        /// 
        /// <returns>
        /// A <see cref="T:System.TimeSpan"/> that indicates the amount of time that the associated process has spent utilizing the CPU. This value is the sum of the <see cref="P:System.Diagnostics.Process.UserProcessorTime"/> and the <see cref="P:System.Diagnostics.Process.PrivilegedProcessorTime"/>.
        /// </returns>
        public ExceptionableResult<TimeSpan> TotalProcessorTime { get; private set; }

        /// <summary>
        /// Gets the user processor time for this process.
        /// </summary>
        /// 
        /// <returns>
        /// A <see cref="T:System.TimeSpan"/> that indicates the amount of time that the associated process has spent running code inside the application portion of the process (not inside the operating system core).
        /// </returns>
        public ExceptionableResult<TimeSpan> UserProcessorTime { get; private set; }

        /// <summary>
        /// Gets the amount of the virtual memory allocated for the associated process.
        /// </summary>
        /// 
        /// <returns>
        /// The amount of virtual memory, in bytes, allocated for the associated process.
        /// </returns>
        public ExceptionableResult<long> VirtualMemorySize64 { get; private set; }


        /// <summary>
        /// Gets the amount of physical memory allocated for the associated process.
        /// </summary>
        /// 
        /// <returns>
        /// The amount of physical memory, in bytes, allocated for the associated process.
        /// </returns>
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
