SELECT TOP 5 
        [Booking].[ID] as ID,
        [Booking].[Price] as ֳ��,
        [Booking].[BoughtTime] as ���_�������,
        [Booking].[FlightRefId] as ID_�����,
        [Booking].[PassengerRefId] as ID_��������
  FROM [Booking]
  ORDER BY [Booking].[BoughtTime] DESC;