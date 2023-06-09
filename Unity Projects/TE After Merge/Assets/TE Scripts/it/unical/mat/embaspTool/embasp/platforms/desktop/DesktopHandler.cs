﻿using System;
using System.Collections.Generic;
using UnityEngine;

namespace it.unical.mat.embasp.platforms.desktop
{
    using ICallback = it.unical.mat.embasp.@base.ICallback;
    using Handler = it.unical.mat.embasp.@base.Handler;
    using InputProgram = it.unical.mat.embasp.@base.InputProgram;
    using OptionDescriptor = it.unical.mat.embasp.@base.OptionDescriptor;
    using Output = it.unical.mat.embasp.@base.Output;

    public class DesktopHandler : Handler
    {
        private readonly DesktopService service;

        public DesktopHandler(DesktopService service) => this.service = service;

        public override void StartAsync(ICallback c, IList<int> program_index, IList<int> option_index)
        {
            IList<InputProgram> input_programs = CollectPrograms(program_index);
            IList<OptionDescriptor> input_options = CollectOptions(option_index);
            service.StartAsync(c, input_programs, input_options);
        }
        public override void StopProcess()
        {
            try
            {
                if (service.solver_process!=null && service.solver_process.StartTime!= null && !service.solver_process.HasExited)
                {
                    service.solver_process.Kill();
                }
            }
            catch (Exception e)
            {
                Debug.Log("Tried to kill dlv but exception occurred");
                Debug.Log(e);
            }
        }
        public override Output StartSync(IList<int> program_index, IList<int> option_index)
        {
            IList<InputProgram> input_programs = CollectPrograms(program_index);
            IList<OptionDescriptor> input_options = CollectOptions(option_index);
            return service.StartSync(input_programs, input_options);
        }
    }
}