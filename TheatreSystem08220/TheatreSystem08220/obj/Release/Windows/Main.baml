   M S B A M L   `   `   `  ���� M  ITheatreSystem08220, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:TheatreSystem08220.WindowsTheatreSystem08220.Windows  %    TheatreSystem08220.Windows.Main   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     :local(clr-namespace:TheatreSystem08220.Windows       � Title$
  Main��$	��766��$
��1366��.���  � RowDefinitions �� $
��Auto ��� $��* �.+�c� .@�]� $��0��.+�`� $	��Top=�.�c� .@�o� .@�m� $
��File��.@�m� $��New..��.@�m� -    m�Name$ fileNewReports��$��Report��m� -   $ fileNewPerformance��$��Performance Entry��m� -   $ fileNewBooking��$��Booking��m� -   $ fileNewNewsletter��$��
Newsletter��m� $
��Save���� -    ��Name$ 
tabControl��$��Stretch=�$��0,23,0,0q�$��Stretch=�$��2��.@��� -    ��Name$ homeTab��$
��Home��.��� .+�� $��	1,1,3,-20q�$��Stretch=�$��Stretch=� � ColumnDefinitions �� $��* � �� $��* ��� $��* ��� $��3* �.+�� $��Center=�$��Center=�$��2�� � 	Resources  �� 
TargetType �� Property	 �� Value��%I   '��       �� " ��.���  � ��$	 50,50q���  � ��$	 50,50q�.+��� -   
 ��Name$
 playScheduleButton��$��16(�$��Play Schedule��$
��Left=�$	��Top=��� -   $
 bookingButton��$��16(�$��Booking/Reservations��$
��Left=�$	��Top=��� -	   $
 newsletterButton��$��16(�$��
Newsletter��$
��Left=�$	��Top=��� -
   $
 reportsButton��$��16(�$��Reports��$
��Left=�$	��Top=��� -    ��Name$ label��$��Theatre Main Menu��$
��Bold"�$��Center=�$��Center=�$��0��$��28(��� -   $ scheduleTab��$��Schedule��$��	2,0,-6,-2q�.���  �� $	��.3* ��� $��* ��� $	��.3* ��� $��* ��� $	��.3* � �� $��* ��� $��* ��� $��* ��� $��* �.+��� $��Upcoming Performances:��$��1��$��1��$��0��$��Center=�$��Center=�$��24(�$
��Bold"��� -    ��Name$ schUpcomingListBox��$��1��$��1��$��3��$��0,0,0,10q��� $��Search Performance��$��3��$��Center=�$��Center=�$��24(�$
��Bold"�(  "System.Windows.Controls.DatePicker  -     Name$ schSearchDatePicker��$��3��$��1��$��Center=�$
��Left=�$��	10,0,10,0q��� $��3��$��1��$	��Top=�$��Center=�$	��150��$��Search By ID:��$��	0,30,10,0q��� -    ��Name$ schIdInputTXT��$��3��$��1��$��Center=�$��Center=�$	��150��$��0,0,10,0q��� -   $
 schIdSearchButton��$��Search��$��3��$��1��$	��140��$��40��$��Center=�$��Right=�$��0,0,10,0q��� -   $' !schSearchPerformanceResultListBox��$��3��$��2��$��2��$��	0,10,0,10q��� -   $
 schExitButton��$
��Exit��$��4��$��3��$��Center=�$��Center=�$��80��$��40���� -   $ 
bookingTab��$��Booking��.���  �� $��* ��� $��* ��� $��* � �� $	��.5* ��� $	��.3* ��� $��* ��� $��* ��� $��* ��� $	��.5* �.+��� -   $
 bookingUpperCircleButton��$��16(�$��Upper Circle��$��1��$��Center=�$��2��$��Center=�$	��140��$��40�����	#FFE6E4E4�� -   $
 bookingDressCircleButton��$��16(�$��Dress Circle��$��1��$��Center=�$��3��$��Center=�$	��140��$��40���� -   $
 bookingStallsButton��$��16(�$��Stalls��$��1��$��Center=�$��4��$��Center=�$	��140��$��40���� -   $ 	areaTitle��$
��Bold"�$��Seating Area��$��28(�$��1��$��Center=�$��Center=��� -   $ remainingTitle��$
��Bold"�$��Remaining seats��$	��28 (�$��2��$
��Left=�$��Center=��� -    ��Name$ bookingUpperCountTXT��$��X/110��$
��Left=�$��Center=�$��2��$��2��$��16(��� -   $ bookingDressCountTXT��$��X/137��$
��Left=�$��Center=�$��2��$��3��$��16(��� -   $ bookingStallsCountTXT��$��X/239��$
��Left=�$��Center=�$��2��$��4��$��16(��� -   $ perfLabelBooking��$
��Bold"�$��Performance��$��Center=�$��Center=�$��28(��� -   $ upcomingLabelBooking��$��	upcoming:��$��Center=�$��1��$	��Top=�$��24(��� -   $ bookingUpcomingListBox��$��0��$��2��$��3��$��	10,0,0,10q��� $��Search by ID:��$��0��$��5��$	��Top=�$��Center=�$��0,10,0,0q��� -   $ bookingIdInputTXT��$��0��$��5��$	��Top=�$��Right=�$	��140��$��	0,15,10,0q�  -    $ bookingDateSearch��$��0��$��5��$	��Top=�$
��Left=�$��	10,10,0,0q��� -!   $
 bookingIdSearchButton��$��0��$��5��$��Bottom=�$��30��$��Search��$��Right=�$	��140��$��10,10,10,10q��� -"   $
 bookingBackButton��$
��Back��$��2��$��5��$��Center=�$��Right=�$	��140��$��40��$��10,10,10,10q��� -#   $ confirmBookingTab��$��ConfirmBooking��.���  �� $	��.2* ��� $��* ��� $	��.2* ��� $��* ��� $	��.2* ��� $��* ��� $	��.2* � �� $��* ��� $��* ��� $��* ��� $��* ��� $��* ��� $��* ��� $��* ��� $��* ��� $��* ��� $��* ��� $��* ��� $	��.5* �.+��� $��1��$��5��$��0��$��Customer Details��$��Center=�$
��Bold"�$��Center=�$��24(��� $��First Name:��$��1��$��0��$��Center=�$
��Left=��� -$   $ confirmFirstNameTXT��$��Center=�$��1��$��1��$
��Left=�$	��150���� $��
Last Name:��$��0��$��2��$��Center=�$
��Left=��� -%   $ confirmLastNameTXT��$��Center=�$
��Left=�$��1��$��2��$	��150���� -&   $!
 confirmSearchAccountsButton��$��1��$��16(�$��3��$��Search Accounts��$	��160��$��Center=�$
��Left=�$��40���� $��Address:��$��0��$��4��$��Center=�$
��Left=��� -'   $ confirmAddressIn1��$��1��$��4��$��Center=�$
��Left=�$	��250���� -(   $ confirmAddressIn2��$��1��$��5��$��Center=�$
��Left=�$	��250���� $��	Postcode:��$��0��$��6��$��Center=�$
��Left=��� -)   $ confirmPostcodeIn��$��Center=�$��1��$��6��$
��Left=�$	��100���� $��Reservation Details��$
��Bold"�$��1��$��5��$��8��$��Center=�$��Center=�$��20(��� $��Performance Title:��$��0��$��Center=�$��Center=�$��9��$
��Wrap=��� -*   $ confirmPerfTitleDisplay��$��1��$��9��$��Center=�$
��Left=�$	��250��$��Title info goes here��|�.  �� $��Seat Number/s:��$
��Wrap=�$��2��$��9��$��Center=�$��Center=��� -+   $ confirmSeatNumbersDisplay��$��Example: (Stalls)A1,A2��|�.  $��3��$��9��$��Center=�$
��Left=�$	��250���� $��Date:��$��4��$��9��$��Center=�$
��Left=��� -,   $ confirmPerfDateDisplay��$��
xx/xx/xxxx��$��5��$��9��$��Center=�$
��Left=�$	��100���� --   $
 confirmReservationButton��$��Confirm Reservation��$��16(�$��3��$��10��$	��150��$
��Left=�$��40��$��Center=��� $��Payment Method:��$
��Wrap=�$��Center=�$
��Left=�$��2��$��1���� -.    ��Name$ confirmPaymentMethodCombo��$��3��$��1��$��Center=�$
��Left=�$	��250��.@�m� $��
Visa Debit��m� $��Visa Credit��m� $��Other��m� $��Reservation (Not paid)���� -/   $&
  confirmApplyBillingAddressButton��$��3��$��3��$��16(�$��Apply Same Address��$	��250��$��40��$��Center=�$
��Left=��� $��Billing Address:��$
��Wrap=�$��2��$��4��$��Center=�$
��Left=��� -0   $ billingAddressIn1��$��3��$��4��$��Center=�$
��Left=�$	��250���� -1   $ billingAddressIn2��$��3��$��5��$��Center=�$
��Left=�$	��250���� $��	Postcode:��$��2��$��6��$��Center=�$
��Left=��� -2   $ billingPostcodeIn��$��Center=�$��3��$��6��$
��Left=�$	��100���� $��Gold Member:��$
��Wrap=�$��4��$��1��$��Center=�$
��Left=��� -3    ��Name$ confirmGoldMemberCheckBox��|�.  {�.   d� 	IsChecked$ FalseY�$��5��$��1��$��Center=�$
��Left=��� $��
Join Date:��$
��Wrap=�$��Center=�$
��Left=�$��4��$��2���� -4   $ confirmGoldJoinDateTXT��$��
xx/xx/xxxx��$��5��$��2��$��Center=�$
��Left=�$	��100��|�.  �� $��Add New Membership��$
��Wrap=�$��Center=�$
��Left=�$��4��$��3���� -5   $ confirmAddNewGoldCheckBox��$��5��$��3��$��Center=�$
��Left=��� -6   $
 confirmBookExitButton��$��5��$��10��$	��150��$��40��$��Cancel��$��16(��� -7   $ 	reportTab��$��Reports��.���  �� $
��0.3* ��� $��* ��� $
��0.3* ��� $��* ��� $
��0.3* ��� $��* � �� $��0.75* ��� $��* ��� $��* ��� $��* ��� $��* �.+��� $��Reports and Statistics��$��24(�$��1��$��4��$��0��$��Center=�$
��Bold"�$��Center=��� $��Upcoming Performances:��$��1��$��1��$��Center=�$
��Left=�$��24(��� $��1��$��2��$��3��$��0,0,0,10q�.@��� $��Testing the scroll box��$��28(��� $��Testing the scroll box��$��28(��� $��Testing the scroll box��$��28(��� $��Testing the scroll box��$��28(��� $��Testing the scroll box��$��28(��� $��Testing the scroll box��$��28(��� $��Testing the scroll box��$��28(��� $��Testing the scroll box��$��28(��� $��Testing the scroll box��$��28(��� $��Testing the scroll box��$��28(��� $��Testing the scroll box��$��28(��� $��Testing the scroll box��$��28(��� $��Testing the scroll box��$��28(��� $��Testing the scroll box��$��28(��� $��Testing the scroll box��$��28(�  -8   $ reportsDateSearch��$��3��$��4��$	��Top=�$
��Left=��� $��search by ID:��$��16(�$��3��$��4��$��Center=�$
��Left=��� -9   $ reportsIdSearch��$��3��$��4��$��Center=�$��Center=�$	��140��$��	20,0,10,0q��� -:   $
 reportsSearchButton��$��Search��$��3��$��4��$	��140��$��40��$��Bottom=�$��Center=�$��20,10,10,10q��� $��3��$��3��$��1��$��3��$��20,20,20,20q�.@��� -;   $ reportsGoldMemberCountTXT��$"��Total Gold members of [DATE]��$��16(��� -<   $! reportsGoldMemberRenewalTXT��$-��'Total Renewals this for month of [DATE]��$��16(��� -=   $! reportsDateOfPerformanceTXT��$*��$performance showing at [TIME] [DATE]��$��16(��� ->   $ reportsSeatsSoldPerfTXT��$$��# seats sold for [performance]��$��16(��� -?   $ reportsSeatsRemainingTXT��$)��## seats remaining for [performance]��$��16(��� -@   $
 reportsUpdateSearchButton��$��4��$��2��$��4��$��Update��$	��140��$��40��$��Center=�$
��Left=�$��30,30,30,30q��� -A   $
 reportsBackButton��$��4��$��2��$��4��$
��Exit��$	��140��$��40��$��Center=�$��Right=�$��30,30,30,30q��� -B   $ newsletterTab��$��
Newsletter��.���  �� $	��.2* ��� $��* ��� $	��.5* ��� $	��.2* � �� $	��.2* ��� $
��.05* ��� $��* ��� $	��.2* �.+��� $��
Newsletter��$��1��$
��Left=�$��Center=�$��24(�$
��Bold"��� $��List of Goldmembers��$��2��$
��Left=�$��Center=�$��24(�$
��Bold"�$��20,10,20,10q�c� $��1��$��1��.@�m� $
��Open��m� $
��Copy��m� $	��Cut��m� $��Paste���� $��	Font size���� .@��� $��8���� $��10���� $��12�� �� 
IsSelected . �� $��14��m� $
��Save��$��40,0,0,0q��� $��1��$��2��.���� �� $��2��$��2��$��20,10,20,10q�.���� -C   $ newsGoldMemberListTXT��$%��It's Austin Powers and Fahjah  ���� -D   $
 newsUpdateMembersButton��$��2��$��3��$	��140��$��40��$��Update��$
��Left=�$��20,20,20,20q��� -E   $
 newsBackButton��$��2��$��3��$	��140��$��40��$
��Exit��$��Right=�$��20,20,20,20q�