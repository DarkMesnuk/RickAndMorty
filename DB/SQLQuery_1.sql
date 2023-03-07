SELECT [Booking].[ID] as ID,
       [Booking].[Price] as Ціна,
       [Booking].[BoughtTime] as Час_Покупки,
       [Booking].[FlightRefId] as ID_Рейсу,
     [Passenger].[ID] as ID_Пасажира,
     [Passenger].[FirstName] as Імя_Пасажира,
     [Passenger].[LastName] as Призвіще_Пасажира,
     [Passenger].[Email] as Пошта_Пасажира,
     [Passenger].[PhoneNumber] as Номер_Телефону_Пасажира,
     [Passenger].[PassportNumber] as Номер_Паспорту_Пасажира
  FROM [Booking]
  INNER JOIN [Passenger]
  ON [Passenger].[ID] = [Booking].[PassengerRefId];