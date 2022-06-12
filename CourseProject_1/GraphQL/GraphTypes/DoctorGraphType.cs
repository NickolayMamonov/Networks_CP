using CourseProject_1.Models;
using GraphQL;
using GraphQL.Types;

namespace CourseProject_1.GraphQL.GraphTypes;

    public class DoctorGraphType:ObjectGraphType<Doctor>
    {
        public DoctorGraphType()
        {
            Name = "Doctor";
            Field(p => p.Id, true);
            Field(p => p.Name, false);
            Field(p => p.Patients, true, typeof(ListGraphType<PatientGraphType>));
        }
    }