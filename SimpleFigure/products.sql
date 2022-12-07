/* 
���������� ������
	� ���� ������ MS SQL Server ���� �������� � ���������. 
	������ �������� ����� ��������������� ����� ���������, 
	� ����� ��������� ����� ���� ����� ���������. �������� SQL 
	������ ��� ������ ���� ��� ���� �������� � ��� ���������. 
	���� � �������� ��� ���������, �� ��� ��� ��� ����� ������ ����������.
*/

-- ������ ������� ������
select * 
from products p
left join link_product_category l
on p.productid = l.productid
left join categories c on l.categoryid = c.categoryid;

/* 
������� �������� � ��������� ������ ��. 

�������: 
	products - ������ ��������;
	categories - ������ ���������
	link_product_category - ������ ����� ������ ��������� � ���������.

����������: 
	������� �� �������, ��� ��� ������������� �� ����� �������� ������ ��������� ���������� ��� ���.

--������� ������ ��������� � ���������
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[link_product_category]') AND type in (N'U'))
DROP TABLE [dbo].[link_product_category]

CREATE TABLE [dbo].[link_product_category](
	[productid] [int] NOT NULL,
	[categoryid] [int] NOT NULL,
 CONSTRAINT [IX_link_product_category] UNIQUE NONCLUSTERED 
(
	[productid] ASC,
	[categoryid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

--��������
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[products]') AND type in (N'U'))
DROP TABLE [dbo].[products]
GO

CREATE TABLE [dbo].[products](
	[productid] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_products] PRIMARY KEY CLUSTERED 
(
	[productid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

--���������
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[categories]') AND type in (N'U'))
DROP TABLE [dbo].[categories]

CREATE TABLE [dbo].[categories](
	[categoryid] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_categories] PRIMARY KEY CLUSTERED 
(
	[categoryid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

--��������� ������� �� ������� ��������� � ���������
ALTER TABLE [dbo].[link_product_category]  WITH CHECK ADD  CONSTRAINT [FK_link_product_category_products] FOREIGN KEY([productid])
REFERENCES [dbo].[products] ([productid])

ALTER TABLE [dbo].[link_product_category] CHECK CONSTRAINT [FK_link_product_category_products]

ALTER TABLE [dbo].[link_product_category]  WITH CHECK ADD  CONSTRAINT [FK_link_product_category_categories] FOREIGN KEY([categoryid])
REFERENCES [dbo].[categories] ([categoryid])

ALTER TABLE [dbo].[link_product_category] CHECK CONSTRAINT [FK_link_product_category_categories]

--���������� ������
insert into products (name) values ('product1');
insert into products (name) values ('product2');
insert into products (name) values ('product3');
insert into products (name) values ('product4');
insert into products (name) values ('product5');
insert into products (name) values ('product6');
insert into products (name) values ('product7');
insert into products (name) values ('product8');
insert into products (name) values ('product9');
insert into products (name) values ('product10');

insert into categories (name) values ('category1');
insert into categories (name) values ('category2');
insert into categories (name) values ('category3');
insert into categories (name) values ('category4');
insert into categories (name) values ('category5');
insert into categories (name) values ('category6');
insert into categories (name) values ('category7');
insert into categories (name) values ('category8');
insert into categories (name) values ('category9');
insert into categories (name) values ('category10');

insert into link_product_category (productid, categoryid) values (1, 1);
insert into link_product_category (productid, categoryid) values (1, 2);
insert into link_product_category (productid, categoryid) values (1, 3);
insert into link_product_category (productid, categoryid) values (5, 6);
insert into link_product_category (productid, categoryid) values (6, 6);
insert into link_product_category (productid, categoryid) values (7, 6);
*/