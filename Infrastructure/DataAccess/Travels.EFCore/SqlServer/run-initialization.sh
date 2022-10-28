sleep 10s

# Run the setup script to create the DB and the schema in the DB
/opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P yourStrong.Password -d master -i newShore.sql