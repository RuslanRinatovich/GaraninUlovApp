   M S B A M L   `   `   `  ����C  ?SportApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:SportAppSportApp  5   	       SportApp.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:SportApp     5   	   _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  6.   -   5          � WindowStartupLocation$  CenterScreen=�5	   	      base_window#��[  5
   	   $	��450��5   	   $	��800��6    � Icon$/ )/SportApp;component/Resources/fishing.ico��6"    � Title 5      ��  �� ElementName$ 	MainFrame�� �� Path$ Content.Title�.��5      �  � RowDefinitions 5   
   �� 5      $��75 �6   �� 5      $��* �6   �� 5      $��30 �6   .+�5   
   (  "MaterialDesignThemes.Wpf.ColorZone  $��5q�6%     main#��[ 63   }�.  
�������   Mode$ Custom=�6�   .��5      ]� ��. .+�5      �� -   5         ��Name$ TextBlockName��5      $
��auto��63   $��40��6@   $��Right=�6L   
���   �6c   �� 5       �� Orientation$ 
Horizontal=�6    $
��Left=�69   .+�5      �� $,��&/SportApp;component/Resources/logo.png��6   $��10q�6L   $
��Left=�5      �� 5      $
��16,0q�6%   $��Center=�68   $
��Bold"�6T     MaterialDesignShadowBrush#��[ 6f   $��ООО УЛОВ��5   !    $  MaterialDesignHeadline5TextBlock#��[ 61   �� 5       -   5        	 ��Name$	 BtnEditGoods��5       
 � ToolTip$
 Товары��6b    # MaterialDesignFlatLightBgButton#��[ 6s   ��64   0  *MaterialDesignThemes.Wpf.PackIconExtension     Kind$
 Fish=�6�   �� 5!      -   5        $	 BtnEditOrders��5!      $
 Заказы��6g   #��[ 6x   ��65     $ Ballot=�6�   �� 5"      -   5        $	 BtnBack��5"      $
 
Назад��6d   #��[ 6v   ��6/     $ 	ArrowBack=�6�   5$      5%      5&       � 5'   
   -   5          �Name$ 	MainFrame��5'      $��1��6#    
 akcent#��[ 60     � NavigationUIVisibility$ Hidden=�5(      $��1q�5)      5*      � 5-   
   $��2��6     
additional#��[ 6   5.      5/      