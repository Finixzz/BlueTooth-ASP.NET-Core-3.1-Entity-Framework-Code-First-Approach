using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlueTooth.Models.Interfaces
{
    public interface IAppointmentRepository
    {
        Appointment GetAppointment(int id);

        IEnumerable<Appointment> GetAppointments();

        Appointment CreateAppointment(Appointment appointment);

        Appointment EditAppointment(Appointment appointment, int id);

        Appointment DeleteAppointment(int id);
    }
}
