using CourseProject_1.GraphQL.GraphTypes;
using CourseProject_1.GraphQL.Services;
using GraphQL;
using GraphQL.Types;

namespace CourseProject_1.GraphQL.Queries;

public class PatientQuery:ObjectGraphType
{
    private readonly IPatientService _service;
        
    public PatientQuery(IPatientService service)
    {
        _service = service;
            
        Field<ListGraphType<PatientGraphType>>("patients", "Query for take all patients",
            resolve:e =>_service.GetAllPatients());
        Field<PatientGraphType>("patient", "Query for take patient",
            new QueryArguments(MakeNonNullStringArgument("id", "ID patient")),
            resolve: e => _service.GetPatientById(Int32.Parse(e.GetArgument<string>("id"))));
    }
    private QueryArgument MakeNonNullStringArgument(string name, string description) {
        return new QueryArgument<NonNullGraphType<StringGraphType>> {
            Name = name, Description = description
        };
    }
    
}