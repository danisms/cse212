using System.Diagnostics;
using System.Text.Json;
using System.Text.RegularExpressions;

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
    ///
    /// </summary>
    /// <param name="words">An array of 2-character words (lowercase, no duplicates)</param>
    public static string[] FindPairs(string[] words)
    {
        // SOLUTION:
        // step 1: create a set out of the inputed words
        // step 2: create another empty set to store paires of words found
        // step 3: loop through the created words set
        // step 4: invert word, make sure the inverted word is not same as initia word and search for the inverted word in the set
        // step 5: if inverted word is found remove the word from the set
        // step 6: add words found into the created empty set
        // step 7: at the end of the loop, return the found paried words set.
        // TODO Problem 1 - ADD YOUR CODE HERE
        var wordsSet = new HashSet<string>(words);
        var pairedWords = new HashSet<string>();
        foreach (string word in wordsSet)
        {
            // invert word
            string invertedWord = $"{word[1]}{word[0]}";
            if (word != invertedWord)
            {
                if (wordsSet.Contains(invertedWord))
                {
                    // add word and inverted word into pairedWords set
                    pairedWords.Add($"{word} & {invertedWord}");
                    // remove inverted word from wordsSet
                    wordsSet.Remove(invertedWord);
                }
            }
        }

        return [.. pairedWords];  // convert to an array of strings.
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
        // SOLUTION:
        // get degree from fields;
        // check if degree isn't present in degrees dictionary;
        // if not present add degree to degrees and set the value to 1;
        // if present increment the value of the degree by 1;
        var degrees = new Dictionary<string, int>();
        foreach (var line in File.ReadLines(filename))
        {
            var fields = line.Split(",");
            // TODO Problem 2 - ADD YOUR CODE HERE
            var degree = fields[3];  // get degree
            if (degrees.ContainsKey(degree))
            {
                degrees[degree] += 1;
            }
            else
            {
                degrees[degree] = 1;
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
        // SOLUTION:
        // step 1: check if word one is same as word two and return false if true; else;
        // step 2: convert words into lowercase and remove spaces;
        // step 3: create a dictionary of both words seperately, using the letters as the key and 
        // the value representing the number of times the letters appears;
        // step 4: check if both dictionaries have the same length
        // finally compare both words keys and values if same return true, else return false;
        // TODO Problem 3 - ADD YOUR CODE HERE

        // check if both words are same
        if (word1 == word2)
        {
            return false;
        }

        // check if words is anagram
        var word1Dictionary = CreateCharDictionary(word1);
        var word2Dictionary = CreateCharDictionary(word2);

        // check if both dictionaries have the same length
        if (word1Dictionary.Count != word2Dictionary.Count)
        {
            return false;
        }

        // FOR DEBUGING PURPOSE
        // Debug.WriteLine("WORD 1 DICTIONARY");
        // foreach (var pair in word1Dictionary)
        // {
        //     Debug.WriteLine($"Key: {pair.Key}, Value: {pair.Value}");
        // }

        // Debug.WriteLine("\nWORD 2 DICTIONARY");
        // foreach (var pair in word2Dictionary)
        // {
        //     Debug.WriteLine($"Key: {pair.Key}, Value: {pair.Value}");
        // }

        // Check if the two word dictionaries are equal. Return true if they match; otherwise, return false.
        bool isAnagram = true;
        foreach (var pair in word1Dictionary)
        {
            // first check if dictionary 2 contain the search key from dictionary 1
            if (!word2Dictionary.ContainsKey(pair.Key))
            {
                isAnagram = false;
            }
            else
            {
                // check if the value in dictionary 2 is same as the value in dictionary 1
                if (word2Dictionary[pair.Key] != pair.Value)
                {
                    isAnagram = false;
                }
            }
        }

        return isAnagram;

        // HELPER FUNCTION
        static Dictionary<char, int> CreateCharDictionary(string word, bool isCaseSensitive = false, bool ignoreSpace = true)
        {
            if (!isCaseSensitive)
            {
                // convert word to lowercase
                word = word.ToLowerInvariant();
            }

            if (ignoreSpace)
            {
                word = word.Replace(" ", "");  // remove white spaces from anywhere in the string
                // // remove white spaces, tab spaces or any white space at all, which apprears anywhere in the string.
                // word = Regex.Replace(word, @"\s+", "");
            }

            // Debug.WriteLine($"Clean Word: {word}");  // for testing purpose

            var wordDictionary = new Dictionary<char, int>();

            foreach (var letter in word)
            {
                if (wordDictionary.ContainsKey(letter))
                {
                    wordDictionary[letter] += 1;
                }
                else
                {
                    wordDictionary[letter] = 1;
                }
            }

            return wordDictionary;
        }
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

        // output each place earthquake has happened today and it's magnitude
        var earthquakesDescriptions = new List<string>{};
        foreach (Feature feature in featureCollection.Features)
        {
            var formatedString = $"{feature.Properties.Place} - Mag {feature.Properties.Mag}";
            earthquakesDescriptions.Add(formatedString);
        }

        return [.. earthquakesDescriptions];
    }
}