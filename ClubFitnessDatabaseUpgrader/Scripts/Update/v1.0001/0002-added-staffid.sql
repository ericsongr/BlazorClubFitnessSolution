

IF NOT EXISTS(select 1 from INFORMATION_SCHEMA.columns where table_name = 'AspNetUsers' and column_name = 'StaffId')
BEGIN
	alter table AspNetUsers add StaffId int not null default(90000)


	ALTER TABLE [dbo].[AspNetUsers]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUsers_StaffId_Staff_StaffId] FOREIGN KEY([StaffId])
	REFERENCES [dbo].[Staff] ([StaffId])


	ALTER TABLE [dbo].[AspNetUsers] CHECK CONSTRAINT [FK_AspNetUsers_StaffId_Staff_StaffId]
END
GO


