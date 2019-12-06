using System;
using System.Collections.Generic;
using System.Linq;

namespace NumberGenerator.Logic
{
	/// <summary>
	/// Beobachter, welcher auf einen vollständigen Quick-Tipp wartet: 6 unterschiedliche Zahlen zw. 1 und 45.
	/// </summary>
	public class QuickTippObserver : IObserver
	{
		#region Fields

		private readonly IObservable _numberGenerator;

		#endregion

		#region Properties

		public List<int> QuickTippNumbers { get; private set; } = new List<int>();
		public int CountOfNumbersReceived { get; private set; } = 0;

		#endregion

		#region Constructor

		public QuickTippObserver(IObservable numberGenerator)
		{
			_numberGenerator = numberGenerator ?? throw new ArgumentNullException($"{nameof(numberGenerator)} war Null");
			_numberGenerator.Attach(this);
		}

		#endregion

		#region Methods

		public void OnNextNumber(int number)
		{
			if (!QuickTippNumbers.Contains(number) && number > 0 && number < 46)
			{
				QuickTippNumbers.Add(number);
			}
			CountOfNumbersReceived++;
			if(QuickTippNumbers.Count == 6)
			{
				DetachFromNumberGenerator();
			}
		}

		public override string ToString()
		{
			throw new NotImplementedException();
		}

		private void DetachFromNumberGenerator()
		{
			_numberGenerator.Detach(this);
		}

		#endregion
	}
}
