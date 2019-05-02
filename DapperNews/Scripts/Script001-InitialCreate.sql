GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[NewsComments](
	[CommentAuthor] [nvarchar](max) NOT NULL,
	[Comment] [nvarchar](max) NOT NULL,
	[DateOfCommentPosting] [datetime] NOT NULL,
	[NewsId] [uniqueidentifier] NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[News](
	[Uncos] [nvarchar](120) NOT NULL,
	[UncosAuthor] [nvarchar](1024) NOT NULL,
	[DateOfPublication] [datetime] NOT NULL,
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO