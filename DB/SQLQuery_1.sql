SELECT [Booking].[ID] as ID,
       [Booking].[Price] as ֳ��,
       [Booking].[BoughtTime] as ���_�������,
       [Booking].[FlightRefId] as ID_�����,
     [Passenger].[ID] as ID_��������,
     [Passenger].[FirstName] as ���_��������,
     [Passenger].[LastName] as �������_��������,
     [Passenger].[Email] as �����_��������,
     [Passenger].[PhoneNumber] as �����_��������_��������,
     [Passenger].[PassportNumber] as �����_��������_��������
  FROM [Booking]
  INNER JOIN [Passenger]
  ON [Passenger].[ID] = [Booking].[PassengerRefId];