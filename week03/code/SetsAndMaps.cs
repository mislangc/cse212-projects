using System.Text.Json;

public static class SetsAndMaps
{
    /// <summary>
    /// The words parameter contains a list of two character 
    /// words (lower case, no duplicates). Using sets, find an O(n) 
    /// solution for returning all symmetric pairs of words.  
    ///
    /// For example, if words was: [am, at, ma, if, fi], we would return :
    ///
    /// ["am & ma", "if & fi"]
    ///
    /// The order of the array does not matter, nor does the order of the specific words in each string in the array.
    /// at would not be returned because ta is not in the list of words.
    ///
    /// As a special case, if the letters are the same (example: 'aa') then
    /// it would not match anything else (remember the assumption above
    /// that there were no duplicates) and therefore should not be returned.
    /// </summary>
    /// <param name="words">An array of 2-character words (lowercase, no duplicates)</param>
    public static string[] FindPairs(string[] words)
    {
        // TODO Problem 1 - ADD YOUR CODE HERE

        var unique = new HashSet<string>();
        var pairs = new HashSet<string>();

        foreach (var word in words)
        {
            string reversed = "";
            foreach (var letter in word)
            {
                reversed = letter + reversed;
                if (!unique.Contains(reversed) || word[0] == word[1])
                {
                    unique.Add(word);
                }
                else
                {
                    pairs.Add($"{word} & {reversed}");
                }
            }

        }
        var index = 0;
        string[] listPairs = new string[pairs.Count];
        foreach (var pair in pairs)
        {
            listPairs[index] = pair;
            index++;
        }
        return listPairs;
    }

    /// <summary>
    /// Read a census file and summarize the degrees (education)
    /// earned by those contained in the file.  The summary
    /// should be stored in a dictionary where the key is the
    /// degree earned and the value is the number of people that 
    /// have earned that degree.  The degree information is in
    /// the 4th column of the file.  There is no header row in the
    /// file.
    /// </summary>
    /// <param name="filename">The name of the file to read</param>
    /// <returns>fixed array of divisors</returns>
    public static Dictionary<string, int> SummarizeDegrees(string filename)
    {
        var degrees = new Dictionary<string, int>();
        foreach (var line in File.ReadLines(filename))
        {
            var fields = line.Split(",");
            // TODO Problem 2 - ADD YOUR CODE HERE
            if (!degrees.ContainsKey(fields[3]))
            {
                degrees.Add(fields[3], 1);
            }
            else
            {
                degrees[fields[3]] += 1;
            }
        }

        return degrees;
    }

    /// <summary>
    /// Determine if 'word1' and 'word2' are anagrams.  An anagram
    /// is when the same letters in a word are re-organized into a 
    /// new word.  A dictionary is used to solve the problem.
    /// 
    /// Examples:
    /// is_anagram("CAT","ACT") would return true
    /// is_anagram("DOG","GOOD") would return false because GOOD has 2 O's
    /// 
    /// Important Note: When determining if two words are anagrams, you
    /// should ignore any spaces.  You should also ignore cases.  For 
    /// example, 'Ab' and 'Ba' should be considered anagrams
    /// 
    /// Reminder: You can access a letter by index in a string by 
    /// using the [] notation.
    /// </summary>
    public static bool IsAnagram(string word1, string word2)
    {
        // TODO Problem 3 - ADD YOUR CODE HERE
        var word1Letters = new Dictionary<string, int>();
        var word2Letters = new Dictionary<string, int>();

        for (var i = 0; i < word1.Length; i++)
        {
            var letter = word1[i].ToString().ToLower();
            if (letter.ToString() != " ")
            {
                if (word1Letters.ContainsKey(letter))
                    word1Letters[letter]++;
                else
                    word1Letters.Add(letter, 1);
            }
        }

        for (var i = 0; i < word2.Length; i++)
        {
            var letter = word2[i].ToString().ToLower();
            if (letter != " ")
            {
                if (word2Letters.ContainsKey(letter))
                    word2Letters[letter]++;
                else
                    word2Letters.Add(letter, 1);
            }
        }

        //This code was from a google search. I had to because I was stuck in problem 3 for almost 5 hours
        //This code checks if both dictionaries have the same keys with the same values regardless of key order
        bool areEqual = word1Letters.Count == word2Letters.Count && !word1Letters.Except(word2Letters).Any();

        return areEqual;
    }

    /// <summary>
    /// This function will read JSON (Javascript Object Notation) data from the 
    /// United States Geological Service (USGS) consisting of earthquake data.
    /// The data will include all earthquakes in the current day.
    /// 
    /// JSON data is organized into a dictionary. After reading the data using
    /// the built-in HTTP client library, this function will return a list of all
    /// earthquake locations ('place' attribute) and magnitudes ('mag' attribute).
    /// Additional information about the format of the JSON data can be found 
    /// at this website:  
    /// 
    /// https://earthquake.usgs.gov/earthquakes/feed/v1.0/geojson.php
    /// 
    /// </summary>
    public static string[] EarthquakeDailySummary()
    {
        const string uri = "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";
        using var client = new HttpClient();
        using var getRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);
        using var jsonStream = client.Send(getRequestMessage).Content.ReadAsStream();
        using var reader = new StreamReader(jsonStream);
        var json = reader.ReadToEnd();
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        var featureCollection = JsonSerializer.Deserialize<FeatureCollection>(json, options);

        // TODO Problem 5:
        // 1. Add code in FeatureCollection.cs to describe the JSON using classes and properties 
        // on those classes so that the call to Deserialize above works properly.
        // 2. Add code below to create a string out each place a earthquake has happened today and its magitude.
        // 3. Return an array of these string descriptions.
        var set = new HashSet<string>();
        foreach (var item in featureCollection.Features)
        {
            set.Add($"{item.Properties.Place} - Mag {item.Properties.Mag}");
        }

        var index = 0;
        string[] earthquakes = new string[set.Count];
        foreach (var place in set)
        {
            earthquakes[index] = place;
            index++;
        }
        return earthquakes;
    }
}