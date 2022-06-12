using CourseProject_1.GraphQL.GraphTypes;
using CourseProject_1.GraphQL.Services;
using CourseProject_1.Models;
using GraphQL;
using GraphQL.Types;

namespace CourseProject_1.GraphQL.Mutation;

public class PatientMutation:ObjectGraphType
{
    private readonly IPatientService _service;
        
        public PatientMutation(IPatientService service)
        {
            _service = service;

            Field<PatientGraphType>("createPatient",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "Name" },
                    new QueryArgument<NonNullGraphType<StringGraphType>>{Name = "Doctor"},
                    new QueryArgument<NonNullGraphType<StringGraphType>>{Name ="Diagnosis"}
                ),
                resolve: tContext =>
                {
                    var Name = tContext.GetArgument<string>("Name");
                    var Doctor = tContext.GetArgument<string>("Doctor");
                    var Diagnosis = tContext.GetArgument<string>("Diagnosis");

                    var newPatient = new Patient()
                    {
                        Name = Name,
                        Doctor = _service.CheckDoctor(Doctor)!=default?_service.CheckDoctor(Doctor):new Doctor{Name = Doctor},
                        Diagnosis = _service.CheckDiagnosis(Diagnosis)!=default?_service.CheckDiagnosis(Diagnosis):new Diagnosis
                            {Name = Diagnosis}
                    };
                    var patient = _service.AddPatient(newPatient);


                    return patient;
                });

            Field<PatientGraphType>("updatePatient",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<StringGraphType>>{Name = "id"},
                    new QueryArgument<NonNullGraphType<StringGraphType>> {Name = "Name"}
                ),
                resolve: tContext =>
                {
                    var id =int.Parse(tContext.GetArgument<string>("id"));
                    var Name = tContext.GetArgument<string>("Name");

                    var newPatient = new Patient()
                    {
                        Name = Name
                    };
                    var patient = _service.UpdatePatient(newPatient, id);

                    return patient;
                }); 
            
            
            Field<PatientGraphType>("deletePatient",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<StringGraphType>>{Name = "id"}
                ),
                resolve: tContext =>
                {
                    var id =int.Parse(tContext.GetArgument<string>("id"));
                    
                    var patient = _service.DeletePatient(id);

                    return patient;
                }); 
        }
}