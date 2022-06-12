using CourseProject_1.GraphQL.Mutation;
using CourseProject_1.GraphQL.Queries;
using CourseProject_1.GraphQL.Services;

namespace CourseProject_1.GraphQL.Schema;

public class PatientSchema:global::GraphQL.Types.Schema
{
    public PatientSchema(IPatientService service)
    {
        Query = new PatientQuery(service);
        Mutation = new PatientMutation(service);
    }
}