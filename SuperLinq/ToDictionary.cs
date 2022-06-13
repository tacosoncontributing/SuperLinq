﻿namespace SuperLinq;

public static partial class SuperEnumerable
{
	/// <summary>
	/// Creates a <see cref="Dictionary{TKey,TValue}" /> from a sequence of
	/// <see cref="KeyValuePair{TKey,TValue}" /> elements.
	/// </summary>
	/// <typeparam name="TKey">The type of the key.</typeparam>
	/// <typeparam name="TValue">The type of the value.</typeparam>
	/// <param name="source">The source sequence of key-value pairs.</param>
	/// <returns>
	/// A <see cref="Dictionary{TKey, TValue}"/> containing the values
	/// mapped to their keys.
	/// </returns>

	public static Dictionary<TKey, TValue> ToDictionary<TKey, TValue>(
		this IEnumerable<KeyValuePair<TKey, TValue>> source)
		where TKey : notnull =>
		source.ToDictionary(comparer: default);

	/// <summary>
	/// Creates a <see cref="Dictionary{TKey,TValue}" /> from a sequence of
	/// <see cref="KeyValuePair{TKey,TValue}" /> elements. An additional
	/// parameter specifies a comparer for keys.
	/// </summary>
	/// <typeparam name="TKey">The type of the key.</typeparam>
	/// <typeparam name="TValue">The type of the value.</typeparam>
	/// <param name="source">The source sequence of key-value pairs.</param>
	/// <param name="comparer">The comparer for keys.</param>
	/// <returns>
	/// A <see cref="Dictionary{TKey, TValue}"/> containing the values
	/// mapped to their keys.
	/// </returns>

	public static Dictionary<TKey, TValue> ToDictionary<TKey, TValue>(
		this IEnumerable<KeyValuePair<TKey, TValue>> source,
		IEqualityComparer<TKey>? comparer)
		where TKey : notnull
	{
		if (source == null) throw new ArgumentNullException(nameof(source));
		return source.ToDictionary(e => e.Key, e => e.Value, comparer);
	}

	/// <summary>
	/// Creates a <see cref="Dictionary{TKey,TValue}" /> from a sequence of
	/// tuples of 2 where the first item is the key and the second the
	/// value.
	/// </summary>
	/// <typeparam name="TKey">The type of the key.</typeparam>
	/// <typeparam name="TValue">The type of the value.</typeparam>
	/// <param name="source">The source sequence of couples (tuple of 2).</param>
	/// <returns>
	/// A <see cref="Dictionary{TKey, TValue}"/> containing the values
	/// mapped to their keys.
	/// </returns>

	public static Dictionary<TKey, TValue> ToDictionary<TKey, TValue>(
		this IEnumerable<(TKey Key, TValue Value)> source)
		where TKey : notnull =>
		source.ToDictionary(comparer: default);

	/// <summary>
	/// Creates a <see cref="Dictionary{TKey,TValue}" /> from a sequence of
	/// tuples of 2 where the first item is the key and the second the
	/// value. An additional parameter specifies a comparer for keys.
	/// </summary>
	/// <typeparam name="TKey">The type of the key.</typeparam>
	/// <typeparam name="TValue">The type of the value.</typeparam>
	/// <param name="source">The source sequence of couples (tuple of 2).</param>
	/// <param name="comparer">The comparer for keys.</param>
	/// <returns>
	/// A <see cref="Dictionary{TKey, TValue}"/> containing the values
	/// mapped to their keys.
	/// </returns>

	public static Dictionary<TKey, TValue> ToDictionary<TKey, TValue>(
		this IEnumerable<(TKey Key, TValue Value)> source,
		IEqualityComparer<TKey>? comparer)
		where TKey : notnull
	{
		if (source == null) throw new ArgumentNullException(nameof(source));
		return source.ToDictionary(e => e.Key, e => e.Value, comparer);
	}
}