namespace ThAmCo.Events.Services;

public class CateringService : ICateringService
{

    private readonly HttpClient _client;
    public CateringService()
    {
        _client = GetHttpClient();
    }
    private static HttpClient GetHttpClient()
    {
        HttpClient client = new();
        string baseUrl = "https://localhost:7173";
        client.BaseAddress = new Uri(baseUrl);
        client.DefaultRequestHeaders.Accept.ParseAdd("application/json");
        return client;
    }

    public async Task<List<FoodItemDTO>> GetAllFoodItems()
    {
        var foodItems = new List<FoodItemDTO>();
        try
        {

            HttpResponseMessage response = await _client.GetAsync("/api/FoodItems");
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                foodItems = JsonConvert.DeserializeObject<List<FoodItemDTO>>(content);
            }
            else
            {
                Console.WriteLine("Failed to fetch data. Status code: " + response.StatusCode);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }


        return foodItems;
    }
    public async Task<List<FoodBookingDTO>> GetAllFoodBookings()
    {
        var foodBookings = new List<FoodBookingDTO>();
        try
        {

            HttpResponseMessage response = await _client.GetAsync("/api/FoodBookings");
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                foodBookings = JsonConvert.DeserializeObject<List<FoodBookingDTO>>(content);

            }
            else
            {
                Console.WriteLine("Failed to fetch data. Status code: " + response.StatusCode);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }

        return foodBookings;
    }

    public async Task<bool> DeleteFoodBooking(int id)
    {
        var isDeleted = false;
        try
        {
            HttpResponseMessage response = await _client.DeleteAsync($"/api/FoodBookings/{id}");
            if (response.IsSuccessStatusCode)
            {
                isDeleted = true;
                return isDeleted;

            }
            else
            {
                Console.WriteLine("Failed to delete data. Status code: " + response.StatusCode);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
        return isDeleted;
    }
    public async Task<bool> CancelFoodBooking(int id)
    {
        var isCanceled = false;

        try
        {
            using HttpClient client = GetHttpClient();
            var httpContent = new StringContent("a", Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PutAsync($"/api/FoodBookings/{id}/cancel", httpContent);

            if (response.IsSuccessStatusCode)
            {
                isCanceled = true;
            }
            else
            {
                Console.WriteLine("Failed to delete data. Status code: " + response.StatusCode);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }

        return isCanceled;
    }

    public async Task<MenuDTO> GetMenuWithFoodItems(int id)
    {
        try
        {

            HttpResponseMessage response = await _client.GetAsync($"/api/Menus/{id}/FoodItems");
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<MenuDTO>(content);

            }
            else
            {
                Console.WriteLine("Failed to fetch data. Status code: " + response.StatusCode);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
        return null;
    }

    public async Task<int?> CreateFoodBooking(FoodBookingDTO foodBookingDTO)
    {
        try
        {
            string jsonContent = JsonConvert.SerializeObject(foodBookingDTO);
            HttpContent content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _client.PostAsync("/api/FoodBookings", content);

            if (response.IsSuccessStatusCode)
            {
                string res = await response.Content.ReadAsStringAsync();
                if (int.TryParse(res, out int intValue))
                {
                    return intValue;
                }
                else
                {
                    return null;
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }

        return null;
    }

    public async Task<FoodBookingDTO> GetFoodBooking(int id)
    {
        var booking = new FoodBookingDTO();
        try
        {

            HttpResponseMessage response = await _client.GetAsync($"/api/FoodBookings/{id}");
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                booking = JsonConvert.DeserializeObject<FoodBookingDTO>(content);
            }
            else
            {
                Console.WriteLine("Failed to fetch data. Status code: " + response.StatusCode);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
        return booking;
    }

    public async Task<bool> EditFoodBooking(int id, FoodBookingDTO foodBookingDTO)
    {
        var isUpdated = false;

        try
        {
            var jsonContent = JsonConvert.SerializeObject(foodBookingDTO);
            var httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _client.PutAsync($"/api/FoodBookings/{id}/edit", httpContent);

            if (response.IsSuccessStatusCode)
            {
                isUpdated = true;
            }
            else
            {
                Console.WriteLine("Failed to update data. Status code: " + response.StatusCode);
                return isUpdated;
            }

        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }

        return isUpdated;
    }

    public async Task<List<MenuDTO>> GetAllMenus()
    {
        var menus = new List<MenuDTO>();
        try
        {

            HttpResponseMessage response = await _client.GetAsync("/api/Menus");
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                menus = JsonConvert.DeserializeObject<List<MenuDTO>>(content);

            }
            else
            {
                Console.WriteLine("Failed to fetch data. Status code: " + response.StatusCode);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }

        return menus;
    }

    public async Task<bool> CreateMenu(string menuName)
    {
        var isCreated = false;
        var postData = new
        {
            menuName,
        };

        try
        {
            string jsonContent = JsonConvert.SerializeObject(postData);
            HttpContent content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _client.PostAsync("/api/Menus", content);

            if (response.IsSuccessStatusCode)
            {
                string res = await response.Content.ReadAsStringAsync();
                return true;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }

        return isCreated;
    }

    public async Task<bool> EditMenu(int id, string newName)
    {
        var isUpdated = false;
        var postData = new
        {
            menuId = id,
            menuName = newName
        };

        try
        {

            var jsonContent = JsonConvert.SerializeObject(postData);
            var httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _client.PutAsync($"/api/Menus/{id}/", httpContent);

            if (response.IsSuccessStatusCode)
            {
                isUpdated = true;
            }
            else
            {
                Console.WriteLine("Failed to update data. Status code: " + response.StatusCode);
                return isUpdated;
            }

        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }

        return isUpdated;
    }

    public async Task<bool> EditFoodItemsInMenu(int id, int[] foodItemIdsList)
    {
        var isUpdated = false;
        var postData = new
        {
            menuId = id,
            foodItems = foodItemIdsList
        };

        try
        {

            var jsonContent = JsonConvert.SerializeObject(postData);
            var httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _client.PutAsync($"/api/Menus/FoodItem/{id}/Edit", httpContent);

            if (response.IsSuccessStatusCode)
            {
                isUpdated = true;
            }
            else
            {
                Console.WriteLine("Failed to update data. Status code: " + response.StatusCode);
                return isUpdated;
            }

        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }

        return isUpdated;
    }

    public async Task<bool> DeleteMenu(int id)
    {
        var isDeleted = false;
        try
        {
            HttpResponseMessage response = await _client.DeleteAsync($"/api/Menus/{id}");
            if (response.IsSuccessStatusCode)
            {
                isDeleted = true;
                return isDeleted;
            }
            else
            {
                Console.WriteLine("Failed to delete data. Status code: " + response.StatusCode);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
        return isDeleted;

        throw new NotImplementedException();
    }

    public async Task<bool> CreateFoodItem(PostFoodItemDTO foodItemDTO)
    {
        var isCreated = false;
        try
        {
            string jsonContent = JsonConvert.SerializeObject(foodItemDTO);
            HttpContent content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _client.PostAsync("/api/FoodItems", content);

            if (response.IsSuccessStatusCode)
            {
                string res = await response.Content.ReadAsStringAsync();
                var createdFoodItem = JsonConvert.DeserializeObject<FoodItemDTO>(res);
                return true;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }


        return isCreated;
    }

    public async Task<FoodItemDTO> GetFoodItem(int id)
    {
        var foodBookings = new FoodItemDTO();
        try
        {

            HttpResponseMessage response = await _client.GetAsync($"/api/FoodItems/{id}");
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                foodBookings = JsonConvert.DeserializeObject<FoodItemDTO>(content);

            }
            else
            {
                Console.WriteLine("Failed to fetch data. Status code: " + response.StatusCode);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }

        return foodBookings;
    }

    public async Task<bool> EditFoodItem(int id, FoodItemDTO foodItemDTO)
    {
        var isUpdated = false;

        try
        {

            var jsonContent = JsonConvert.SerializeObject(foodItemDTO);
            var httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _client.PutAsync($"/api/FoodItems/{id}", httpContent);

            if (response.IsSuccessStatusCode)
            {
                isUpdated = true;
            }
            else
            {
                Console.WriteLine("Failed to update data. Status code: " + response.StatusCode);
                return isUpdated;
            }

        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }

        return isUpdated;
    }


    public async Task<bool> DeleteFoodItem(int id)
    {
        var isDeleted = false;
        try
        {
            HttpResponseMessage response = await _client.DeleteAsync($"/api/FoodItems/{id}");
            if (response.IsSuccessStatusCode)
            {
                isDeleted = true;
                return isDeleted;
            }
            else
            {
                Console.WriteLine("Failed to delete data. Status code: " + response.StatusCode);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
        return isDeleted;
    }

}
