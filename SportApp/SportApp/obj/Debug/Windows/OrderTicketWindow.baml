   M S B A M L   `   `   `  ����C  ?SportApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:SportApp.WindowsSportApp.Windows  5   	   (    "SportApp.Windows.OrderTicketWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:SportApp.Windows     5   	     � Title$  
Талон��5         base_window#��[  6   $	��500��6?   $	��600��5	   	   $	��400��6   $	��400��6%    � WindowStartupLocation$ CenterScreen=�5
   	    � Icon$, &/SportApp;component/Resources/icon.ico��5   	   .��5      �  � ColumnDefinitions 5   
   �� 5      $	��200 �6   �� 5       � RowDefinitions 5   
   �� 5      $��40 �6   �� 5      $��34 �6   �� 5      $��34 �6   �� 5      $��34 �6   �� 5      $��34 �6   �� 5      $��34 �6   �� 5      �� 5      $��40 �6   �� 5      $��40 �6   .+�5   
   �   
additional#��[ 6   $��2��68   �� 5   
   $,��&/SportApp;component/Resources/logo.png��6   $��10q�5      $
��Left=�5      �� 5    
   $��0��6   $��ООО УЛОВ��6!   $��2��62   $��Center=�5!      $��Center=�5"      #��[ 5#      $��20(�5$      $
��Bold"�5%      �� 5&   
   -   5         ��Name$ TextBlockOrderNumber��5'   *   $��Заказ №��5&      $��1��6%   $��0��62   $��2��5'      $��Center=�5(      $��Center=�5)      $��20(�5*      $
��Bold"�5+      �� 5-   
   $��Дата заказа��6   $��2��6(   $��0��65   $
��Left=�5.      $��60 0 0 0q�6/   $��Center=�5/        item_textblock#��[ 50      $
��Bold"�51      �� 52   
   -   5        $ TextBlockOrderCreateDate��52      $��2��53      $��1��6!   $��Center=�54      $
��Left=�55      #��[ 56      $
��Bold"�57      �� 58   
   $!��Дата получения��6   $��3��6+   $��0��68   $
��Left=�59      $��60 0 0 0q�6/   $��Center=�5:      #��[ 5;      $
��Bold"�5<      �� 5=   
   -   5        $  TextBlockOrderDeliveryDate��5=      $��3��68   $��1��5>      $��Center=�6%   $
��Left=�5?      #��[ 6/   $
��Bold"�5@      �� 5A   
   $��Пункт выдачи��6   $��4��6)   $��0��66   $
��Left=�5B      $��60 0 0 0q�6/   $��Center=�5C      #��[ 5D      $
��Bold"�5E      �� 5F   
   -   5        $ TextBlockPickupPoint��5F      $��4��62   $��1��5G      $��Center=�6$   $
��Left=�5H      #��[ 6/   $
��Bold"�5I      �� 5J   
   $��Код получения��6   $��5��6*   $��0��67   $
��Left=�5K      $��60 0 0 0q�6/   $��Center=�5L      #��[ 5M      $
��Bold"�5N      �� 5O   
   -   5        $ TextBlockOrderGetCode��5O      $��5��63   $��1��5P      $��Center=�6$   $
��Left=�5Q      #��[ 6/   $
��Bold"�5R      &   System.Windows.Controls.DataGrid  5U   
   -   5          Name$ DataGridOrderItems��5U      $��6��6/      AutoGenerateColumns .     
IsReadOnly . $��2��5X      	   SelectionMode$	 Single=�5Y      
   Columns
 5[      4  .System.Windows.Controls.DataGridTemplateColumn  5\      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$	 100 6)     WrappedColumnHeaderStyle   HeaderStyle# [ 5]   )      Header$ Изображение��5^   )      CellTemplate 5_      �� 5`      .R�5a      �� ��6$   ��  �� Path$ Key.GetPhoto�5b      5d      0  *System.Windows.Controls.DataGridTextColumn  5e      # [ 5f   %   $+ %Наименование товара��5g   %   $ * 6B   1  +System.Windows.Controls.DataGridBoundColumn   Binding 5e   %   �� *Key.ProductName+5g   B     5h      # [ 5i   %   $ Количество��5j   %   $ * 69    5h   %   �� *Value.Count+5j   9     5k      # [ 5l   %   $9 3Стоимость товара без скидки��5m   %   $ * 6J    5k   %   �� *Key.ProductCost+ �� StringFormat$ c�� �� ConverterCulture$ ru-RU��5m   J     5n      # [ 5o   %   $) #Действующая скидка��5p   %   $ * 6A    5n   %   �� *Key.ProductDiscountAmount+5p   A     5q      # [ 5r   %   $9 3Стоимость товара со скидкой��5s   %   $ * 6J    5q   %   �� *Key.GetPriceWithDiscount+$ c��$ ru-RU��5s   J     5t      # [ 5u   %   $ 
ИТОГО��5v   %   $ * 64    5t   %   �� *Value.Total+$ c��$ ru-RU��5v   4   5x      �� 5z   
   -   5        $ TextBlockTotalCost��5z      $��7��60   $��2��5{      �� 5|   
    �� Orientation$ 
Horizontal=�6   $��8��6.   $��2��5}      $��Center=�5~      .+�5      �� -   5         ��Name$ BtnOk��5�      $	��100��5      $��30��6!   $��OK��5�      5�      �� 5�      -	   5        $ 
BtnSavePDF��5�      $��Сохранить в PDF��5�      $	��160��6/   5�      5�      5�      5�      