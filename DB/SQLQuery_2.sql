SELECT TOP 5 
        [Booking].[ID] as ID,
        [Booking].[Price] as Ціна,
        [Booking].[BoughtTime] as Час_Покупки,
        [Booking].[FlightRefId] as ID_Рейсу,
        [Booking].[PassengerRefId] as ID_Пасажира
  FROM [Booking]
  ORDER BY [Booking].[BoughtTime] DESC;