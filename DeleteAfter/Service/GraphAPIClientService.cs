using DeleteAfter.Helpers;
using Microsoft.Graph;
using System.Net.Http.Headers;

namespace DeleteAfter.Service
{
    public class GraphAPIClientService 
    {
        private readonly IHelper _helper;

        public GraphAPIClientService(IHelper helper)
        {
            _helper = helper;
        }

        public async Task<IEnumerable<Event>> GetEventsFromGraph()
        {
            var token = _helper.GetAccessToken();
            var tokenN = "eyJ0eXAiOiJKV1QiLCJub25jZSI6IjVaWVNZSk0wSkRXMmViaWhZNkhDSVdTUy1jS1dldFc2dXYza0pIWTFLQkEiLCJhbGciOiJSUzI1NiIsIng1dCI6ImpTMVhvMU9XRGpfNTJ2YndHTmd2UU8yVnpNYyIsImtpZCI6ImpTMVhvMU9XRGpfNTJ2YndHTmd2UU8yVnpNYyJ9.eyJhdWQiOiIwMDAwMDAwMy0wMDAwLTAwMDAtYzAwMC0wMDAwMDAwMDAwMDAiLCJpc3MiOiJodHRwczovL3N0cy53aW5kb3dzLm5ldC9kYTQyYjMyZi00ZDBiLTQwNzktOTUxZi1lYjFkYmVhNGUyYzQvIiwiaWF0IjoxNjUyMzY3MDQwLCJuYmYiOjE2NTIzNjcwNDAsImV4cCI6MTY1MjM3MDk4MCwiYWNjdCI6MCwiYWNyIjoiMSIsImFpbyI6IkFWUUFxLzhUQUFBQXVNcUNNay9SKy9sMDgvKzNreEd0QlFJN2VYMDUzM3Z3K09GZnFEU0thNDZGQUJzcnMwc0xJWXNKZVRMU25OQlByNExDaWp2aUc2VHRkd0hkUTYyaXMvMitOMWc2OTYrY1ZxTWlkZXJURFhZPSIsImFtciI6WyJwd2QiLCJyc2EiLCJtZmEiXSwiYXBwX2Rpc3BsYXluYW1lIjoiR3JhcGggRXhwbG9yZXIiLCJhcHBpZCI6ImRlOGJjOGI1LWQ5ZjktNDhiMS1hOGFkLWI3NDhkYTcyNTA2NCIsImFwcGlkYWNyIjoiMCIsImRldmljZWlkIjoiMmIzZmIyNTEtODM5Zi00NjVlLWE1ODAtMmFiMjQwNWI2MGVmIiwiZmFtaWx5X25hbWUiOiJNc29taSIsImdpdmVuX25hbWUiOiJNdXNhIiwiaWR0eXAiOiJ1c2VyIiwiaXBhZGRyIjoiMTAyLjM5LjI3Ljc4IiwibmFtZSI6Ik11c2EgTXNvbWkiLCJvaWQiOiJmZTAyMzAyZi1jYTVmLTRmNWEtYjgwYS04Yjg1ODFmOTYyNWUiLCJvbnByZW1fc2lkIjoiUy0xLTUtMjEtMTI0MjkzMDkwMy01MjkxNzI1MzctMjQ2Njg1OTk4OS0xNzgxOSIsInBsYXRmIjoiMyIsInB1aWQiOiIxMDAzMjAwMUQ1Qzg1MThDIiwicmgiOiIwLkFSQUFMN05DMmd0TmVVQ1ZILXNkdnFUaXhBTUFBQUFBQUFBQXdBQUFBQUFBQUFBUUFHby4iLCJzY3AiOiJDYWxlbmRhcnMuUmVhZCBvcGVuaWQgcHJvZmlsZSBVc2VyLlJlYWQgZW1haWwiLCJzaWduaW5fc3RhdGUiOlsiZHZjX21uZ2QiLCJkdmNfY21wIiwiZHZjX2RtamQiLCJrbXNpIl0sInN1YiI6IlpuYnIyOWRrTWYzT0s4ZmdNUG0xMGRtUWxkSVR5djNfV0M0NC0xbklDZ3ciLCJ0ZW5hbnRfcmVnaW9uX3Njb3BlIjoiQUYiLCJ0aWQiOiJkYTQyYjMyZi00ZDBiLTQwNzktOTUxZi1lYjFkYmVhNGUyYzQiLCJ1bmlxdWVfbmFtZSI6Im1tc29taTJAamhiLmR2dC5jby56YSIsInVwbiI6Im1tc29taTJAamhiLmR2dC5jby56YSIsInV0aSI6ImxZMGZNc0Jwb2tLb3c3d09GdUZtQUEiLCJ2ZXIiOiIxLjAiLCJ3aWRzIjpbImI3OWZiZjRkLTNlZjktNDY4OS04MTQzLTc2YjE5NGU4NTUwOSJdLCJ4bXNfc3QiOnsic3ViIjoiVHItRVUwcFVPQ1l3WjNuS3JiTDFmYk95N1VwNVZPVlgtbVdmSU1kNmVlRSJ9LCJ4bXNfdGNkdCI6MTQ1OTQzMDk2MX0.VEeE-m5K5kCl7YzMquK6THf57FExPpwFRqDV1KYkGZiyyH9iuhXefG-sRyFGAFDS9lUJfb6PcSa7jyrMLc5UUg3vbdTJReUv81yGds9DYh5-c6s00zDXuh29c5NUYB0QmFspjilmU2URuQj3iPSshXAZELAICisVPUG_yarHWeNMzsJUhqSx-5-pIcnBdu1WpCLICN12KJgMI6oNLjR4LCoBOP_fuj_YCKFrSo78S2Kru8pdcBFPtVI49oIZvcWEX4u9pDiBCH31zrtCrfq-l89aT62yJpq7ddiOF8l122pkfhsNhfgjtMe1d6iPTPaEbVvJCdE1KeP8iDNyXQIgpw";

            GraphServiceClient client = new GraphServiceClient(new DelegateAuthenticationProvider(provider =>
            {
                provider.Headers.Authorization = new AuthenticationHeaderValue("Bearer", tokenN);

                return Task.FromResult(0);
            }));

            var startOfWeek =  DateTime.Now;
            var endOfWeek = startOfWeek.AddDays(2);
            var viewOptions = new List<QueryOption>
            {
                new QueryOption("startDateTime", startOfWeek.ToString("o")),
                new QueryOption("endDateTime", endOfWeek.ToString("o"))
            };

            var myEvents = await client.Me.CalendarView
                .Request(viewOptions)
                .Header("Prefer", "outlook.timezone=\"South Africa Standard Time\"")
                .GetAsync();

            var returnedEvent = myEvents.AsEnumerable();

            return returnedEvent;
        }
    }
}
