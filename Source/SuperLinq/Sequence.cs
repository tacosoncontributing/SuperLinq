﻿namespace SuperLinq;

public static partial class SuperEnumerable
{
	/// <summary>Generates a sequence of integral numbers within a specified range.</summary>
	/// <param name="start">The value of the first integer in the sequence.</param>
	/// <param name="count">The number of sequential integers to generate.</param>
	/// <param name="step">The step increment for each returned value.</param>
	/// <returns>
	/// An <see cref="IEnumerable{Int32}"/>that contains
	/// a range of sequential integral numbers.
	/// </returns>
	/// <exception cref="ArgumentOutOfRangeException">
	/// <paramref name="count"/> is less than 0. -or- <paramref name="start"/> + (<paramref name="count"/> -1) * <paramref name="step"/>
	/// cannot be contained by an <see cref="int"/>.
	/// </exception>
	public static IEnumerable<int> Range(int start, int count, int step)
	{
		Guard.IsGreaterThanOrEqualTo(count, 0);
		var max = start + (count - 1) * (long)step;
		Guard.IsBetweenOrEqualTo(max, int.MinValue, int.MaxValue, name: nameof(count));
		return _(start, count, step);

		static IEnumerable<int> _(int start, int count, int step)
		{
			var value = start;
			for (var i = 0; i < count; i++)
			{
				yield return value;
				value += step;
			}
		}
	}

	/// <summary>
	/// Generates a sequence of integral numbers within the (inclusive) specified range.
	/// If sequence is ascending the step is +1, otherwise -1.
	/// </summary>
	/// <param name="start">The value of the first integer in the sequence.</param>
	/// <param name="stop">The value of the last integer in the sequence.</param>
	/// <returns>An <see cref="IEnumerable{Int32}"/> that contains a range of sequential integral numbers.</returns>
	/// <remarks>
	/// This operator uses deferred execution and streams its results.
	/// </remarks>
	/// <example>
	/// <code><![CDATA[
	/// var result = SuperEnumerable.Sequence(6, 0);
	/// ]]></code>
	/// The <c>result</c> variable will contain <c>{ 6, 5, 4, 3, 2, 1, 0 }</c>.
	/// </example>
	public static IEnumerable<int> Sequence(int start, int stop)
	{
		return Sequence(start, stop, start < stop ? 1 : -1);
	}

	/// <summary>
	/// Generates a sequence of integral numbers within the (inclusive) specified range.
	/// An additional parameter specifies the steps in which the integers of the sequence increase or decrease.
	/// </summary>
	/// <param name="start">The value of the first integer in the sequence.</param>
	/// <param name="stop">The value of the last integer in the sequence.</param>
	/// <param name="step">The step to define the next number.</param>
	/// <returns>An <see cref="IEnumerable{Int32}"/> that contains a range of sequential integral numbers.</returns>
	/// <remarks>
	/// When <paramref name="step"/> is equal to zero, this operator returns an
	/// infinite sequence where all elements are equals to <paramref name="start"/>.
	/// This operator uses deferred execution and streams its results.
	/// </remarks>
	/// <example>
	/// <code><![CDATA[
	/// var result = SuperEnumerable.Sequence(6, 0, -2);
	/// ]]></code>
	/// The <c>result</c> variable will contain <c>{ 6, 4, 2, 0 }</c>.
	/// </example>
	public static IEnumerable<int> Sequence(int start, int stop, int step)
	{
		long current = start;

		while (step >= 0 ? stop >= current
						 : stop <= current)
		{
			yield return (int)current;
			current += step;
		}
	}
}
