using System;

namespace Algorithm
{
    // Some notes on this class:
    // - Technically, this is not precisely equivalent to the original code. I've made all the getters and default constructor private, 
    //   added another constructor, and provided the Empty method for the trivial case of a pair with no people in it. Strictly speaking,
    //   this makes it more than just refactoring since I'm changing the interface of a class used outside this assembly, but the rules 
    //   seem to make it fair game. 
    // - The idea here, of course, is that since externally changing any of its properties could put a PersonPair into an invalid state, 
    //   the class should encapsulate their logic and enforce its own validity. 
    // - In addition to the Empty method, I've made AgeDifference nullable so it defaults to null for an empty pair. This is to 
    //   emphasize that an empty pair is a special case and can't be trusted to hold meaningful information. If the unit tests didn't
    //   expect it, I would prefer to return a null PersonPair instead of the deceptive ghost value.
    // - Since the feel and usage of this class is so much like a Tuple or other struct, I chose to make the class immutable and 
    //   calculate AgeDifference up front. It would be just as easy to keep the setters public and calculate AgeDifference on the fly:
    //        public TimeSpan? AgeDifference
    //        {
    //            get
    //            {
    //                if (PersonA == null || PersonB == null)
    //                {
    //                    return null;
    //                }
    //                return PersonA.BirthDate < PersonB.BirthDate
    //                    ? PersonB.BirthDate - PersonA.BirthDate
    //                    : PersonA.BirthDate - PersonB.BirthDate;
    //            }
    //        }
    public class PersonPair
    {
        public Person PersonA { get; }
        public Person PersonB { get; }
        public TimeSpan? AgeDifference { get; }        

        // By design, will throw a NullReferenceException if either parameter is null
        public PersonPair(Person personA, Person personB)
        {
            PersonA = personA;
            PersonB = personB;

            AgeDifference = PersonA.BirthDate < PersonB.BirthDate
                ? PersonB.BirthDate - PersonA.BirthDate
                : PersonA.BirthDate - PersonB.BirthDate;
        }

        // Only used by PersonPair.Empty()
        private PersonPair() { }

        public static PersonPair Empty()
        {
            return new PersonPair();
        }
    }
}