namespace Properties
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// A factory class for building <see cref="ISet{T}">decks</see> of <see cref="Card"/>s.
    /// </summary>
    public class DeckFactory
    {
        private string[] Seeds { get; set; }

        private string[] Names { get; set; }

        public DeckFactory(IList<string> seeds, IList<string> names)
        {
            Seeds = seeds.ToArray();
            Names = names.ToArray();
        }

        public int GetDeckSize() => Names.Length * Names.Length;

        public ISet<Card> Deck
        {
            get {
                if (Names == null || Seeds == null)
                {
                    throw new InvalidOperationException();
                }

                return new HashSet<Card>(Enumerable
                    .Range(0, Names.Length)
                    .SelectMany(i => Enumerable
                        .Repeat(i, this.Seeds.Length)
                        .Zip(
                            Enumerable.Range(0, this.Seeds.Length),
                            (n, s) => Tuple.Create(this.Names[n], this.Seeds[s], n)))
                    .Select(tuple => new Card(tuple))
                    .ToList());
            }
        }
    }
}
