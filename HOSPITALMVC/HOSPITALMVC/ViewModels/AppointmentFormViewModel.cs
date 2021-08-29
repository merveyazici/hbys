using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HOSPITALMVC.Models.EntityFramework;

namespace HOSPITALMVC.ViewModels
{
    public class AppointmentFormViewModel
    {
        public IEnumerable<DOCTOR> doctor { get; set; }
        public IEnumerable<PATIENT> patient { get; set; }
        public APPOINTMENT appointment { get; set; }
    }
}