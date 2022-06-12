using CourseProject_1.Models;
using GraphQL.Types;

namespace CourseProject_1.GraphQL.GraphTypes;

public class DiagnosisGraphType:ObjectGraphType<Diagnosis>
{
    public DiagnosisGraphType()
    {
        Name = "Diagnosis";
        Field(p => p.Id, true);
        Field(p => p.Name, false);
        Field(p => p.Patients, true, typeof(ListGraphType<PatientGraphType>));
    }
}