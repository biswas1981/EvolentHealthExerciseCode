using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EvolentHealthExerciseApi.Utility
{
    public sealed class ProjectLogger
    {
        private static ProjectLogger projectLogger = null;
        private static readonly object padlock = new object();

        private ProjectLogger()
        {

        }

        public Logger GetLogger()
        {
            return LogManager.GetCurrentClassLogger();
        }


        public static ProjectLogger Instance
        {
            get
            {
                if (projectLogger == null)
                {
                    lock (padlock)
                    {
                        if (projectLogger == null)
                        {
                            projectLogger = new ProjectLogger();
                        }
                    }
                }
                return projectLogger;
            }

        }


    }
}