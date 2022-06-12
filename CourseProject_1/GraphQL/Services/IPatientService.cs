using CourseProject_1.Models;

namespace CourseProject_1.GraphQL.Services;

public interface IPatientService
{
    IQueryable<Patient> GetAllPatients();
        
    Patient GetPatientById(int id);

    Patient UpdatePatient(Patient patient, int id);

    Patient AddPatient(Patient patient);

    Patient DeletePatient(int id);

    Doctor CheckDoctor(string name);

    Diagnosis CheckDiagnosis(string name);
}