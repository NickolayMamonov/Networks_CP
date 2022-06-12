using CourseProject_1.Models;
using GraphQL.Types;

namespace CourseProject_1.GraphQL.GraphTypes;

public class PatientGraphType:ObjectGraphType<Patient>
{
    public PatientGraphType()
    {
        Name = "Patient";
        Field(p => p.Id, true);
        Field(p => p.Name, false);
        Field(p => p.Doctor, true, typeof(DoctorGraphType));
        Field(p => p.Diagnosis, true, typeof(DiagnosisGraphType));
    }
}