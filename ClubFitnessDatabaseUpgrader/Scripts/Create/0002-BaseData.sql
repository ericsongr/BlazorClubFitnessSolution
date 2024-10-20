SET IDENTITY_INSERT [dbo].[LookupTypes] ON;

INSERT INTO [dbo].[LookupTypes] ([TypeId], [Type])
VALUES (1, 'Discounted By');

SET IDENTITY_INSERT [dbo].[LookupTypes] OFF;


SET IDENTITY_INSERT [dbo].[LookupTypeItems] ON;

INSERT INTO [dbo].[LookupTypeItems] ([Id], [TypeId], [Description], [IsActive], [IsSystem], [IsShowOnline])
VALUES 
(1, 1, 'By Price', 1, 0, 0),
(2, 1, 'By Percentage', 1, 0, 0),
(3, 1, 'By Amount', 1, 0, 0);

SET IDENTITY_INSERT [dbo].[LookupTypeItems] OFF;
