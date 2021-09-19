using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

namespace katas.web_page_counts
{
    /*
You are in charge of a display advertising program. Your ads are displayed on websites all over the internet. You have some CSV input data that counts how many times that users have clicked on an ad on each individual domain. Every line consists of a click count and a domain name, like this:

counts = [ "900,google.com",
     "60,mail.yahoo.com",
     "10,mobile.sports.yahoo.com",
     "40,sports.yahoo.com",
     "300,yahoo.com",
     "10,stackoverflow.com",
     "20,overflow.com",
     "5,com.com",
     "2,en.wikipedia.org",
     "1,m.wikipedia.org",
     "1,mobile.sports",
     "1,google.co.uk"]

Write a function that takes this input as a parameter and returns a data structure containing the number of clicks that were recorded on each domain AND each subdomain under it. For example, a click on "mail.yahoo.com" counts toward the totals for "mail.yahoo.com", "yahoo.com", and "com". (Subdomains are added to the left of their parent domain. So "mail" and "mail.yahoo" are not valid domains. Note that "mobile.sports" appears as a separate domain near the bottom of the input.)

Sample output (in any order/format):

calculateClicksByDomain(counts) =>
com:                     1345
google.com:              900
stackoverflow.com:       10
overflow.com:            20
yahoo.com:               410
mail.yahoo.com:          60
mobile.sports.yahoo.com: 10
sports.yahoo.com:        50
com.com:                 5
org:                     3
wikipedia.org:           3
en.wikipedia.org:        2
m.wikipedia.org:         1
mobile.sports:           1
sports:                  1
uk:                      1
co.uk:                   1
google.co.uk:            1

n: number of domains in the input
(individual domains and subdomains have a constant upper length)
*/

    public class Solution
    {
        public static Dictionary<string, int> GetPageCounts(string[] counts)
        {
            var dictionary = new Dictionary<string, int>();

            if (counts is not { Length: > 0 })
            {
                return dictionary;
            }

            foreach (var record in counts)
            {
                if (string.IsNullOrWhiteSpace(record))
                {
                    continue;
                }

                var recordColumns = record.Split(',');

                var pageCount = int.Parse(recordColumns[0]);
                var fullDomain = recordColumns[1];
                var domains = fullDomain.Split('.');

                for (var i = 0; i < domains.Length; i++)
                {
                    var domainName = string.Empty;

                    var counter = i;

                    while (counter < domains.Length)
                    {
                        domainName += domains[counter];
                        counter++;

                        if (counter != domains.Length)
                        {
                            domainName += '.';
                        }
                    }

                    if (!dictionary.ContainsKey(domainName))
                    {
                        dictionary.Add(domainName, pageCount);
                    }
                    else
                    {
                        dictionary[domainName] += pageCount;
                    }
                }
            }

            return dictionary;
        }
    }

    [TestFixture]
    public class Tests
    {
        [TestCase]
        public void Should_Work()
        {
            var counts = new[]
            {
                "900,google.com",
                "60,mail.yahoo.com",
                "10,mobile.sports.yahoo.com",
                "40,sports.yahoo.com",
                "300,yahoo.com",
                "10,stackoverflow.com",
                "20,overflow.com",
                "5,com.com",
                "2,en.wikipedia.org",
                "1,m.wikipedia.org",
                "1,mobile.sports",
                "1,google.co.uk"
            };

            var pageCounts = Solution.GetPageCounts(counts);pageCounts["google.com"].Should().Be(900);
            pageCounts["com"].Should().Be(1345);
            pageCounts["mail.yahoo.com"].Should().Be(60);
            pageCounts["yahoo.com"].Should().Be(410);
            pageCounts["mobile.sports.yahoo.com"].Should().Be(10);
            pageCounts["sports.yahoo.com"].Should().Be(50);
            pageCounts["stackoverflow.com"].Should().Be(10);
            pageCounts["overflow.com"].Should().Be(20);
            pageCounts["com.com"].Should().Be(5);
            pageCounts["en.wikipedia.org"].Should().Be(2);
            pageCounts["wikipedia.org"].Should().Be(3);
            pageCounts["org"].Should().Be(3);
            pageCounts["m.wikipedia.org"].Should().Be(1);
            pageCounts["mobile.sports"].Should().Be(1);
            pageCounts["sports"].Should().Be(1);
            pageCounts["google.co.uk"].Should().Be(1);
            pageCounts["co.uk"].Should().Be(1);
            pageCounts["uk"].Should().Be(1);
        }
    }
}