   M S B A M L   `   `   `  ����C  ?SportApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:SportApp.PagesSportApp.Pages  5      #    SportApp.Pages.AddProductPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      X TXceed.Wpf.Toolkit, Version=4.5.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5      (localclr-namespace:SportApp.Pages  5      _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  62     N� Title$:  4Добавление и редактирование��5
         	base_page#��[  5      .��5      �  � RowDefinitions 5   
   �� 5      $	��200 �6   �� 5      $��30 �6   �� 5      $��30 �6   �� 5      $��30 �6   �� 5      $��30 �6   �� 5      $��30 �6   �� 5      $��30 �6   �� 5      $��30 �6   �� 5      $��30 �6   �� 5      $��30 �6   �� 5      $��30 �6   �� 5      $��* �6   �� 5      $��40 �6    � ColumnDefinitions 5   
   �� 5      $	��245 �6   �� 5      .+�5    
   �� -   5         ��Name$ BtnSave��5       $��12��6"   $��Сохранить��60   $��Center=�5!      $	��Top=�6.   $	��120��6F   $��1��5"   &   $��213,3,222,0q�66   �� 5$   
   $��0��6   $��0��6"   $��Изображение��62   $
��20 0q�6F   �� 5%   
   $��1��6   $��0��6!   $!��Артикул товара��61   $
��20 0q�6H   �� 5&   
   $��2��6   $��0��6!   $%��Категория товара��61   $
��20 0q�6J   �� 5'   
   $��3��6   $��0��6!   $+��%Наименование товара��61   $
��20 0q�6M   �� 5(   
   $��4��6   $��0��6!   $,��&Количество на складе��61   $
��20 0q�6N   �� 5)   
   $��5��6   $��0��6!   $'��!Единица измерения��61   $
��20 0q�6K   �� 5*   
   $��6��6   $��0��6!   $ ��Производитель��61   $
��20 0q�6G   �� 5+   
   $��7��6   $��0��6!   $��Поставщик��61   $
��20 0q�6C   �� 5,   
   $��8��6   $��0��6!   $8��2Размер максимальной скидки��61   $
��20 0q�6S   �� 5-   
   $��9��6   $��0��6!   $6��0Размер действующей скидки��61   $
��20 0q�6R   �� 5.   
   $��10��6   $��0��6"   $,��&Стоимость за единицу��62   $
��20 0q�6N   �� 5/   
   $��11��6   $��0��6"   $��Описание��62   $
��20 0q�6C   �� 52   
   -   5         ��Name$ 
ImagePhoto��52      $��0��53      $��1��6   $��10 0 0 0q�6-   $��Stretch=�54      $
��Left=�6,   $	��100��6G   ��52   $   �� *
GetPhoto+54   G   �� 55   
   -   5        $ BtnLoad��55      $��0��6"   $��0��6/   $��	120,5,0,0q�6?   $
��Left=�56      $	��Top=�6,   $��79��57   V   ��6&   0  *MaterialDesignThemes.Wpf.PackIconExtension     Kind$ Upload=�6V   �� 58   
   -   5         ��Name$ TextBoxArtikul��58      $��1��59      $��1��6   $	��0,2q�6/   $
��Auto��6=   ��58   *   �� *ProductArticleNumber+59   =   �� 5:   
   -   5         ��Name$ ComboCategory��5:      $��2��5;      $��1��6     �� DisplayMemberPath$ ProductCategoryName��61   	 �� SelectedValuePath$	 ProductCategoryID��5<      
 �� SelectedItem
 5:   +   �� *ProductCategory+5<      �� 5=   
   -   5        $ TextBoxProductName��5=      $��3��5>      $��1��6   $	��0,2q�6/   $
��Auto��6=   ��5=   .   �� *ProductName+5>   =   %  Xceed.Wpf.Toolkit.IntegerUpDown  5A   
   -   5          Name$" IntegerUpDownQuantityInStock��5A      �  �Xceed.Wpf.Toolkit.Primitives.UpDownBase`1[[System.Nullable`1[[System.Int32, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]   Minimum$ 0X�5B      $��4��6*   $��1��67   %   DisplayDefaultValueOnEmptyText . )  #MaterialDesignThemes.Wpf.HintAssist   Hint$, &Количество на складе��5C         Value 5A   C   �� *ProductQuantityInStock+5C      �� 5F   
   -   5        $ ComboUnitType��5F      $��5��5G      $��1��6    $ UnitTypeName��61   $	 
UnitTypeID��5H      
 5F   +   �� *
UnitType+5H      �� 5J   
   -	   5        $ ComboManufacturer��5J      $��6��5K      $��1��6    $ ProductManufacturerName��61   $	 ProductManufacturerID��5L      
 5J   /   �� *ProductManufacturer+5L      �� 5M   
   -
   5        $ ComboSupplier��5M      $��7��5N      $��1��6    $ ProductSupplierName��61   $	 ProductSupplierrID��5O      
 5M   +   �� *ProductSupplier+5O        5R   
   -   5        $$ IntegerUpDownDiscountAmountMax��5R      $ 0X�5T         Maximum$	 100X�6)   $��8��67   $��1��6D    .  5R   E   �� *ProductMaxDiscountAmount+5T   z     5W   
   -   5        $! IntegerUpDownDiscountAmount��5W      $ 0X�5X      $��9��6*   $��1��67    .  5W   B   �� *ProductDiscountAmount+5X   G   $  Xceed.Wpf.Toolkit.DoubleUpDown  5\   
   -   5          Name$ DoubleUpDownProductCost��5\      �  �Xceed.Wpf.Toolkit.Primitives.UpDownBase`1[[System.Nullable`1[[System.Double, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]   Minimum$ 0X�5]   ;   $��10��6H   $��1��6V   %   DisplayDefaultValueOnEmptyText . �  �Xceed.Wpf.Toolkit.NumericUpDown`1[[System.Nullable`1[[System.Double, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]   FormatString$ c��6�      Value 6   �� *ProductCost+6�   �� 5_   
   -   5        $ TextBoxProductDescription��5_       �� TextWrapping$
 Wrap=�6Y   $��11��5`      $��1��6    $	��0,2q�60   $
��Auto��6>   ��5_   5   �� *ProductDescription+5`   >   5a      5b      