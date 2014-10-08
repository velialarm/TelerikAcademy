--1. Create a table in SQL Server with 10 000 000 log entries (date + text). Search in the table by date range. Check the speed (without caching).

SET NOCOUNT ON
DECLARE @RowCount INT = 10000
WHILE @RowCount > 0
BEGIN
  DECLARE @Text nvarchar(100) =
    'Text ' + CONVERT(nvarchar(100), @RowCount) + ': ' +
    CONVERT(nvarchar(100), newid())
  DECLARE @DATE datetime =
        DATEADD(MONTH, CONVERT(varbinary, newid()) % (50 * 12), getdate())
  INSERT INTO Messages(MsgText, MsgDate)
  VALUES(@Text, @DATE)
  SET @RowCount = @RowCount - 1
END
SET NOCOUNT OFF
 
WHILE (SELECT COUNT(*) FROM Messages) < 1000000
BEGIN
  INSERT INTO Messages(MsgText, MsgDate)
  SELECT MsgText, MsgDate FROM Messages
END
 
DECLARE @Counter INT = 0
WHILE (SELECT COUNT(*) FROM Messages) < 10000000
BEGIN
  INSERT INTO Messages(MsgText, MsgDate)
  SELECT MsgText + CONVERT(VARCHAR, @Counter), MsgDate FROM Messages
  SET @Counter = @Counter + 1
END
 
CHECKPOINT; DBCC DROPCLEANBUFFERS; -- Empty the SQL Server cache
 
SELECT * FROM Messages m
WHERE m.MsgDate BETWEEN '01-08-1999' AND '01-01-2000'
 
-- takes 21-24 seconds without cache and 1 second with cache
 
CREATE INDEX IDX_Messages_MsgDate ON Messages(MsgDate)
 
-- takes 8 seconds
 
 
--2.Add an index to speed-up the search by date. Test the search speed (after cleaning the cache).
 
 
CREATE INDEX IDX_Messages_MsgDate ON Messages(MsgDate)
 
CHECKPOINT; DBCC DROPCLEANBUFFERS; -- Empty the SQL Server cache
 
SELECT * FROM Messages m
WHERE m.MsgDate BETWEEN '01-08-1999' AND '01-01-2000'
 
-- takes 20-27 seconds
 
-- Conclusion: Index on date was of no use to me whatsoever. Did several tests with dropping and creating
-- index each time and clearing cache.
 
 
 
--3.Add a full text index for the text column. Try to search with and without the full-text index and compare the speed.
 
 
CREATE FULLTEXT CATALOG MessagesFullTextCatalog
WITH ACCENT_SENSITIVITY = OFF
 
CREATE FULLTEXT INDEX ON Messages(MsgText)
KEY INDEX PK_Messages_MsgId
ON MessagesFullTextCatalog
WITH CHANGE_TRACKING AUTO
 
SELECT * FROM Messages
WHERE CONTAINS(MsgText, 'Text%')
 
-- takes 2 seconds
 
CHECKPOINT; DBCC DROPCLEANBUFFERS; -- Empty the SQL Server cache
SELECT COUNT(*) FROM Messages
WHERE CONTAINS(MsgText, 'Text%')
 
-- takes 0 seconds
 
DROP FULLTEXT INDEX ON Messages
DROP FULLTEXT CATALOG MessagesFullTextCatalog
 
CHECKPOINT; DBCC DROPCLEANBUFFERS; -- Empty the SQL Server cache
SELECT * FROM Messages
WHERE MsgText LIKE 'Text%'
 
-- takes more than a minute
 
CHECKPOINT; DBCC DROPCLEANBUFFERS; -- Empty the SQL Server cache
SELECT COUNT(*) FROM Messages
WHERE MsgText LIKE 'Text%'
 
-- takes 20 seconds