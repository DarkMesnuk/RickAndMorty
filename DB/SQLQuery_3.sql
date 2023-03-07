SELECT TOP 3
      [Passenger].[ID] as ID_��������,
      [Passenger].[FirstName] as ���_��������,
      [Passenger].[LastName] as �������_��������,
            COUNT([Booking].[PassengerRefId]) as ʳ������_���������
FROM [Passenger]
INNER JOIN [Booking]
    ON [Passenger].[ID] = [Booking].[PassengerRefId]
GROUP BY [Passenger].[ID], [Passenger].[FirstName], [Passenger].[LastName]
ORDER BY COUNT([Booking].[PassengerRefId]) DESC;