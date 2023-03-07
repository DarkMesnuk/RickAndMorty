SELECT TOP 3
      [Passenger].[ID] as ID_Пасажира,
      [Passenger].[FirstName] as Імя_Пасажира,
      [Passenger].[LastName] as Призвіще_Пасажира,
            COUNT([Booking].[PassengerRefId]) as Кількість_Перельотів
FROM [Passenger]
INNER JOIN [Booking]
    ON [Passenger].[ID] = [Booking].[PassengerRefId]
GROUP BY [Passenger].[ID], [Passenger].[FirstName], [Passenger].[LastName]
ORDER BY COUNT([Booking].[PassengerRefId]) DESC;