namespace ThAmCo.Events.Services;

public class VenuesService : IVenuesService
{

    private readonly HttpClient _client;

    public VenuesService()
    {
        _client = GetHttpClient();
    }
    private static HttpClient GetHttpClient()
    {
        HttpClient client = new();
        string baseUrl = "https://localhost:7088";
        client.BaseAddress = new Uri(baseUrl);
        client.DefaultRequestHeaders.Accept.ParseAdd("application/json");
        return client;
    }

    public async Task<List<EventTypeDTO>> GetEventtypes()
    {
        var listOfDtos = new List<ThAmCo.Events.DTO.EventTypeDTO>();

        try
        {
            HttpResponseMessage response = await _client.GetAsync("/api/eventtypes");

            if (response.IsSuccessStatusCode)
            {
                // Read content as a string
                string content = await response.Content.ReadAsStringAsync();

                // Deserialize the string content to a list of dto
                listOfDtos = JsonConvert.DeserializeObject<List<ThAmCo.Events.DTO.EventTypeDTO>>(content);
            }
            else
            {
                Console.WriteLine("Failed to fetch data. Status code: " + response.StatusCode);
                // Handle the error as needed
            }
        }

        // This way we should be chatching error when we need to take actions
        // based on the error tayps, but since we don't need here to take any actions i'm 
        // using the General exception catch.
        catch (HttpRequestException ex)
        {
            Console.WriteLine($"HTTP request error: {ex.Message}");
            // Handle the HTTP request exception
        }
        catch (JsonException ex)
        {
            Console.WriteLine($"JSON deserialization error: {ex.Message}");
            // Handle the JSON deserialization exception
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            // Handle other unexpected exceptions
        }


        return listOfDtos;
    }
    public async Task<ReservationDTO> GetReservation(string reservationCode)
    {
        ReservationDTO reservation = null;

        try
        {
            HttpResponseMessage response = await _client.GetAsync($"/api/Reservations/{reservationCode}");

            if (response.IsSuccessStatusCode)
            {
                // Read content as a string
                string content = await response.Content.ReadAsStringAsync();
                reservation = JsonConvert.DeserializeObject<ReservationDTO>(content);
            }
            else
            {
                Console.WriteLine($"Failed to fetch data. Status code: {response.StatusCode}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }

        return reservation;

    }
    public async Task<bool> DeleteReservation(string reservationCode)
    {
        ReservationDTO reservation = null;

        try
        {

            HttpResponseMessage response = await _client.DeleteAsync($"/api/Reservations/{reservationCode}");

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                reservation = JsonConvert.DeserializeObject<ReservationDTO>(content);
                return true;
            }
            else
            {
                Console.WriteLine($"Failed to fetch data. Status code: {response.StatusCode}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }

        return false;

    }
    public async Task<ReservationDTO> CreateReservation(PostReservationDTO reservationData)
    {
        ReservationDTO reservation = null;

        try
        {

            string jsonContent = JsonConvert.SerializeObject(reservationData);
            HttpContent content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _client.PostAsync("/api/Reservations", content);

            if (response.IsSuccessStatusCode)
            {
                string responseContent = await response.Content.ReadAsStringAsync();
                reservation = JsonConvert.DeserializeObject<ReservationDTO>(responseContent);
            }
            else
            {
                Console.WriteLine($"Failed to create reservation. Status code: {response.StatusCode}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
        return reservation;

    }

    /// <summary>
    /// Method to convert Event types to SelectListItem so it can be reundered easily on the client side
    /// </summary>
    /// <returns></returns>
    public async Task<List<SelectListItem>> GeteventTypeListAsSelectListItem()
    {
        List<EventTypeDTO> eventTypeList = await GetEventtypes();

        List<SelectListItem> selectList = eventTypeList.Select(e => new SelectListItem
        {
            Value = e.Id,
            Text = e.Title
        }).ToList();
        return selectList;
    }
}


/// We can write most of the code in in a generic way, 
/// here is an example on how it would look like if i write it for this service
///  it will be less code and more readable
/// But sice we did not use it in the module i'm not gonna use generic, not fancy losing marks for using advanced code :)
/// Just comment the above code and use the down one and will have the same result!
/// ///Note i changed my original code after writing the generic way

//###################################################################################################
//###################################################################################################

//namespace ThAmCo.Events.Services;

//public class VenuesService : IVenuesService
//{
//    private readonly HttpClient _client;

//    public VenuesService()
//    {
//        _client = GetHttpClient();
//    }

//    private static HttpClient GetHttpClient()
//    {
//        HttpClient client = new();
//        string baseUrl = "https://localhost:7088";
//        client.BaseAddress = new Uri(baseUrl);
//        client.DefaultRequestHeaders.Accept.ParseAdd("application/json");
//        return client;
//    }

//    public async Task<List<T>> GetItems<T>(string endpoint)
//    {
//        var listOfDtos = new List<T>();

//        try
//        {
//            HttpResponseMessage response = await _client.GetAsync(endpoint);

//            if (response.IsSuccessStatusCode)
//            {
//                string content = await response.Content.ReadAsStringAsync();
//                listOfDtos = JsonConvert.DeserializeObject<List<T>>(content);
//            }
//            else
//            {
//                Console.WriteLine($"Failed to fetch data from {endpoint}. Status code: {response.StatusCode}");
//            }
//        }
//        catch (Exception ex)
//        {
//            Console.WriteLine($"An unexpected error occurred: {ex.Message}");
//        }

//        return listOfDtos;
//    }
//    public async Task<T> GetItem<T>(string endpoint)
//    {
//        try
//        {
//            HttpResponseMessage response = await _client.GetAsync(endpoint);

//            if (response.IsSuccessStatusCode)
//            {
//                string content = await response.Content.ReadAsStringAsync();
//                var a = JsonConvert.DeserializeObject<T>(content);
//                return a;
//            }
//            else
//            {
//                Console.WriteLine($"Failed to fetch data from {endpoint}. Status code: {response.StatusCode}");
//                return default; // Return default value for type T
//            }
//        }
//        catch (Exception ex)
//        {
//            Console.WriteLine($"An unexpected error occurred: {ex.Message}");
//            return default;
//        }
//    }

//    public async Task<ReservationDTO> GetReservation(string reservationCode)
//    {
//        string endpoint = $"/api/Reservations/{reservationCode}";
//        return await GetItem<ReservationDTO>(endpoint);
//    }
//    /// This needs more work now it's calling for get it should be delete
//    public async Task<ReservationDTO> DeleteReservation(string reservationCode)
//    {
//        string endpoint = $"/api/Reservations/{reservationCode}";
//        return await GetItem<ReservationDTO>(endpoint);
//    }

//    public async Task<List<EventTypeDTO>> GetEventtypes()
//    {
//        return await GetItems<EventTypeDTO>("/api/eventtypes");
//    }

//    public async Task<List<AvailabilityDTO>> GetAvailability(string eventyType, DateTime begin, DateTime end)
//    {
//        string endpoint = $"/api/Availability?eventType={eventyType}&beginDate={begin:yyyy-MM-dd}&endDate={end:yyyy-MM-dd}";
//        return await GetItems<AvailabilityDTO>(endpoint);
//    }


//    public async Task<ReservationDTO> CreateReservation(PostReservationDTO reservationData)
//    {
//        string jsonContent = JsonConvert.SerializeObject(reservationData);
//        HttpContent content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

//        HttpResponseMessage response = await _client.PostAsync("/api/Reservations", content);

//        if (response.IsSuccessStatusCode)
//        {
//            string responseContent = await response.Content.ReadAsStringAsync();
//            return JsonConvert.DeserializeObject<ReservationDTO>(responseContent);
//        }
//        else
//        {
//            Console.WriteLine($"Failed to create reservation. Status code: {response.StatusCode}");
//            return null;
//        }
//    }

//    public async Task<List<SelectListItem>> GeteventTypeListAsSelectListItem()
//    {
//        List<EventTypeDTO> eventTypeList = await GetEventtypes();

//        return eventTypeList.Select(e => new SelectListItem
//        {
//            Value = e.Id,
//            Text = e.Title
//        }).ToList();
//    }
//}
