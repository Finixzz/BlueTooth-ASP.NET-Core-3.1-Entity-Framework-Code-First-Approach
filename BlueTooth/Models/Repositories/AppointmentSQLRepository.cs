using BlueTooth.DbContext;
using BlueTooth.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlueTooth.Models.Repositories
{
    public class AppointmentSQLRepository : IAppointmentRepository
    {
        private ApplicationDbContext _context;

        public AppointmentSQLRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public Appointment CreateAppointment(Appointment appointment)
        {
            _context.Appointments.Add(appointment);
            _context.SaveChanges();
            return appointment;
        }

        public Appointment DeleteAppointment(int id)
        {
            Appointment appointmentInDb = _context.Appointments.SingleOrDefault(c => c.Id == id);
            _context.Appointments.Remove(appointmentInDb);
            _context.SaveChanges();
            return appointmentInDb;
        }

        public Appointment EditAppointment(Appointment appointment, int id)
        {
            Appointment appointmentInDb = _context.Appointments.SingleOrDefault(c => c.Id == id);
            appointmentInDb.IsValid = appointment.IsValid;
            appointmentInDb.Time = appointment.Time;
            _context.SaveChanges();
            return appointmentInDb;
        }

        public Appointment GetAppointment(int id)
        {
           return  _context.Appointments.SingleOrDefault(c => c.Id == id);
        }

        public IEnumerable<Appointment> GetAppointments()
        {
            return _context.Appointments;
        }
    }
}
