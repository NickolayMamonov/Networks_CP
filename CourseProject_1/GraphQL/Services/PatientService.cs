using CourseProject_1.Data;
using CourseProject_1.Models;
using Microsoft.EntityFrameworkCore;

namespace CourseProject_1.GraphQL.Services;

public class PatientService:IPatientService
{
    private readonly HospitalContext _context;
    
    public PatientService(HospitalContext context)
    {
        _context = context;
    }
    
    public IQueryable<Patient> GetAllPatients()
    {
        return _context.Patients
            .Include(t => t.Doctor)
            .Include(t=>t.Diagnosis)
            .Select(p => p);
    }

    public Patient GetPatientById(int id)   
    {
        return _context.Patients
            .Include(t => t.Doctor)
            .Include(t=>t.Diagnosis)
            .SingleOrDefault(p=>p.Id == id)!;
    }

    public Patient UpdatePatient(Patient patient, int id)
    {
        var updatingPatient = _context.Patients.SingleOrDefault(t => t.Id == id);
        updatingPatient.Id = id;
        updatingPatient.Name = patient.Name;
        _context.Patients.Update(updatingPatient);
        _context.SaveChanges();

        return updatingPatient;
    }

    public Patient AddPatient(Patient patient)
    {
        var result = _context.Patients.Add(patient).Entity;
        _context.SaveChanges();
        return result;
    }

    public Patient DeletePatient(int id)
    {
        var deletePatient = _context.Patients.FirstOrDefault(p => p.Id == id);
        _context.Patients.Remove(deletePatient);
        _context.SaveChanges();

        return deletePatient;
    }

    public Doctor CheckDoctor(string name)
    {
        var result = _context.Doctors.FirstOrDefault(t => t.Name.Equals(name));
        return result;
    }

    public Diagnosis CheckDiagnosis(string name)
    {
        var result = _context.Diagnoses.FirstOrDefault(t => t.Name.Equals(name));
        return result;
    }
}