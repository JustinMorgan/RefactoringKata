using System.Collections.Generic;
using System.Linq;

namespace Algorithm
{
    public class Finder
    {
        private readonly List<Person> _people;

        public Finder(List<Person> people)
        {
            _people = people;
        }

        // Note: As method names go, this one isn't great. It doesn't make clear what we're trying to do, which is find 
        // information about the age relationships in the set. On the other hand, it's hard to imagine an intuitive
        // name that covers both operations this method makes available.
        // The name of the class is even worse, but since this is just an example and the class only has one method, I've 
        // left it as-is. It's not clear what the scope of this class is supposed to be, so naming it would just be
        // speculating on an imaginary theme.
        public PersonPair FindAgeRange(SearchType searchType)
        {
            PersonPair result;

            // If we have less than two people, there are no age differences to compare. Bail out and return the 
            // special empty-pair object to show that we can't find a meaningful result.
            if (_people.Count < 2)
            {
                result = PersonPair.Empty();
            }
            else
            {
                // Both types of search start with sorting everyone by age, so do that first.
                var sortedPeople = _people.OrderBy(person => person.BirthDate).ToList();

                // If we're looking for the greatest age difference, that's easy enough. It will always be the youngest 
                // and oldest people in the list.
                if (searchType == SearchType.GreatestDifference)
                {
                    result = new PersonPair(sortedPeople.First(), sortedPeople.Last());
                }
                // If we're looking for the smallest age difference, that's a lot trickier. Fortunately, we've already
                // sorted everyone by age. Whichever two people are closest in age, we know they're next to each other
                // in that list.
                else
                {
                    // Pair each person with the one right after it, apart from the last one in the list.
                    var pairs = sortedPeople
                        .Take(sortedPeople.Count - 1)
                        .Select((person, index) => new PersonPair(person, sortedPeople[index + 1]));

                    result = pairs.OrderBy(pair => pair.AgeDifference).First();
                }
            }

            return result;    
        }
            
    }
}