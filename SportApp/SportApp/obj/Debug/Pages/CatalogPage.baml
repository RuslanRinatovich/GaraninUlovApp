   M S B A M L   `   `   `  ����C  ?SportApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:SportApp.PagesSportApp.Pages  5           SportApp.Pages.CatalogPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      (localclr-namespace:SportApp.Pages  5      -   5          N� Title$  Каталог��5
         	base_page#��[  5      .��5      �  � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $��50 �6   �� 5      $��* �6   .+�5   
   � $��0��6   $��Stretch=�6!     main#��[ 6?   .+�5      ��  �� Orientation$ 
Horizontal=�6   .+�5      �� -   5         ��Name$ 
TBoxSearch��5   &   $	��275��6   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$H BВведите название товара или артикул��6:   5      5      �� 5      $ 
Horizontal=�6   .+�5      �� -   5         ��Name$ ComboDiscont��5   )   $	��275��6   $# Выберите скидку��6@   .@�5      �� $��Все диапазоны��6#   �� 5      $��	0 - 9.99%��6#   �� 5      $��10 - 14.99 %��6#   �� 5       $��15% и более��6#   5!      5"      �� 5$      $ 
Horizontal=�6   .+�5&      �� -   5        $ 	ComboSort��5'      $	��275��5&      $! Сортировать по��6(   .@�5)      �� $!��По возрастанию��6#   �� 5*      $��По убыванию��6#   5+      5,      5-      �� 5.   
   -   5         ��Name$ TextBlockCount��5.   !   $��1��6   $	��300��69   $
��Left=�6E   �� 5/   
   -   5        $ TextBlockBasketInfo��5/   !   $��1��6   $	��200��6>   $��Right=�6J   $��	0 0 140 0q�6f   %  MaterialDesignThemes.Wpf.Badged  50   
   -   5          Name$ BadgeBasketCount��50   I   $��1��6    $��Right=�6-   $��Center=�6c   $��2 0 10 0q�6~   .��51      �� -   5         ��Name$ 	BtnBasket��51   Z   $
��auto��6   ��6$   0  *MaterialDesignThemes.Wpf.PackIconExtension  	   Kind$	 BasketUnfill=�6m   52      �� 54   
   -	   5        
 ��Name$
 ListBoxProducts��54      $��Visible=�55       �� SelectedValuePath$ AgentId��56      $��2��61   $��0��6>     	good_item#��[ 57      ��59      �� 5:      .R�5;      � $��Stretch=�6    � UseLayoutRounding .  � ColumnDefinitions 5<      �� 5=      $��60 �6/   �� 5>      $��* �6/   �� 5?      $��80 �6/   .+�5A      �� $��0��6    $��60��60   $��40��6;   $��Uniform=�5B       $��5 0 5 0q�5C       ��5B   2   ��  �� Path$ GetPhoto�5C       �� 5D      $��1��6%   .+�5F      �� $��2q�6(   $��16(�63   $
��Bold"�6A   $
��Auto��5H   (   $
��Left=�65   ��5G   (   �� $ ProductName�5H   5   �� 5I      $��2q�6(   $��14(�63   $
��Bold"�6A   $
��Auto��5K   (   $
��Left=�65   ��5J   (   �� $ ProductArticleNumber� �� StringFormat$ Артикул: {0}��5K   5   �� 5M      $��2q�6(   $��16(�63   $
��Auto��5O   (   $
��Left=�65   ��5N   (   �� $1 +ProductManufacturer.ProductManufacturerName�$% Производитель: {0}��5O   5   �� 5P      $ 
Horizontal=�6)   .+�5Q   "   �� $��2q�6,   $��16(�67   $
��Auto��5S   ,   $
��Left=�69   
��� � ���5R   ,   �� $ GetPriceWithDiscount�$ c�� �� ConverterCulture$ ru-RU��y�5T   ,   �� *GetVisibility+6Q   �� 5U   "   $��2q�6,   $��16(�67   $
��Auto��5W   ,   $
��Left=�69   
���  ����5V   ,   �� $ ProductCost�$ c��$ ru-RU����5X   ,   �� *GetTextDecoration+6Z   5Y      5Z      �� 5[      $��80��6%   $��Center=�60   $��2��5\   %   $��5q�65   $��26(�6@   ��5]   %   �� $ ProductDiscountAmount�$  {0} %��5^      5_       � ContextMenu 5a      �� 5b      .@�5c      m� -
   5        $$��Добавить в заказ��5c      6R   5d      5f      5h      5i      