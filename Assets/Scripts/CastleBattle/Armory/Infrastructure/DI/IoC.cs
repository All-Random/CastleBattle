using System;
using System.Collections.Generic;

public static class IoC
{
	private static IDictionary<Type, object> registeredTypes = new SortedList<Type, object>();

	public static void Register<T>(Type toRegister)
	{
		registeredTypes.Add (typeof(T), toRegister);
	}

	public static T Resolve<T>()
	{
		return (T)registeredTypes [typeof(T)];
	}
}

