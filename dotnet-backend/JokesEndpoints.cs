
namespace HackathonDotnetServer;




internal static class JokesEndpoints
{
    public static WebApplication DefineJokesEndpoints(this WebApplication app)
    {
        // --------------------------------------------------------------
        // GET which responds with a random joke in JSON as a Joke object
        //---------------------------------------------------------------

        app.MapGet("jokes/random",

        [SwaggerOperation(Summary = "Gets a random joke", Description = $"The random joke as a {nameof(Joke)} object.", Tags = ["Jokes"])]
        [SwaggerResponse(StatusCodes.Status200OK, "Everything went well", typeof(Joke))]
        [SwaggerResponse(StatusCodes.Status502BadGateway, "The external API to fetch jokes is not available or is malfunctioning")]
        async () =>
        {
            var joke = await app.Services.GetRequiredService<JokeProvider>().GetRandomJoke();
            if (joke is null)
            {
                return Results.Problem(detail: "The external API to fetch jokes is not available or is malfunctioning", statusCode: StatusCodes.Status502BadGateway);
            }
            return Results.Ok(joke);

        });

        return app;
    }
}
