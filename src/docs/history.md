

1.8.27g
- snoop_filter
  - can correctly switch views - snoop positions are computed correctly


1.8.27e
- snoop_filter
  - snooping on single column works
  - ctrl-alt-f / ctrl-alt-l -> clear snoop
  - disabled alt-f4 on snoop_around_form


1.8.27d
- snoop_filter
  - the filter is cumulated - from all snoop around filters!!!!
  - remembers selection of each snoop
  - snooping (on another thread) works - even cares about surrounding rows
	- this could be for "all log" or "surrounding X entries"
	  - if "surrounding X entries", we do cache, but when we press it again, we keep the existing pre-computed list of items, and recompute the number of entries
	  - for now, this will be preset -> if more than 10000 entries -> snoop around 1000. If less, go through all of it
  - done: needs to be general - so that i can have any "quick filter" to be applied to all items
    - (in quick filter) - later it will be very easy to add the other quick filter : start/end , start-date/end-date
	- this is per view!!!
  - can be queried on a specific match_item/line
  - when it's computed for row X, and very close to that row, I need to reuse it (insted of reswooping)
  - need to know which columns are snooped (filtered) and which not
  - initially works rather decent - still quite a few things to fix


1.8.27c
- snoop_filter
  - the expander control: made the buttons into panels, in order not to have any border


1.8.27b
- snoop_filter
  - reshowing the expander as a control (not to steal focus)


1.8.27a
- snoop_filter 
  - have a dictionary based on info_type
  - on different log -> clear all snoops
  - need to know which columns are snooped (filtered) and which not
  - can change parent, so that i can apply them on description pane
- problem - creating the snoop forms and showing them steals focus from the smart edit


1.8.26
- snoop around
  - whenever i show it (expand), see if gone through all items. if not, snoop around again
  - tested filtering, removing filter - works correctly
  - visually show if we are snooping or not + tooltip on what is selected
     - collapsing will pause the "snoop" process (looking for values)
       - restarting it will resume (but i'll have a timeout after which the task stops completely)


1.8.25
- scheletron for snooping around
  - tested in test_ui


1.8.24
- fix #80 : after selection made, sometimes not deselected on move


1.8.23
- on errors/fatal errors - show in status bar + link to github issues
- allow parsers/text readers to add warnings as well - which are shown in the status bar
- fix #52 Import cvs file (exported from Windows Events Log) -> Message column not shown correctly 
  - several fixes at processing csv files


1.8.22
- fix #63 rewritten file -> need to delete all bookmarks
- fix #31 bookmark + toggle showing everything


1.8.21
- fix #83 home / end hotkeys don't work correctly anymore


1.8.20
- fix #85 - log file gets rewritten -> clear filter (ctrl-alf-f) + show full log (ctrl-alt-l)


1.8.19
- fix #12 color filter -> clear selection


1.8.18
- fix #14
  - fg + bg -> use select_color_form
  - "to filter" - if fg not set, set it now
  - bg - if default, don't actually place it in the filter itself


1.8.17
- Search : added "To filter" button
	- allow negating the filter
	  - add this to the UI -> also, when negating (negating simply excludes those lines)
	  - allow "help" -> https://github.com/jtorjo/logwizard/wiki/Filters - updated this page, to explain a bit about Filters (that you can have several, and so on)
	- select Color/Match Color/default color?
	  - the color is taken from the filter (fg + bg) colors + when fg/bg colors change, update the color of the button
	- If "all columns" -> create the filter in such a way that it's an OR of all the columns
	  - note: at this time, we don't yet match-color any columns except for the $msg column


1.8.16
- fixes: when setup kit run first time, did not load setup sample correctly


1.8.15
- release to public


1.8.14
- fix #81
  - recognized numbers (decimals) + hexa + guids correctly


1.8.13
- fix #84
  - file line-by-line + nlog/log4net syntax: {} -> treat it as an alias


1.8.12
- dropping file: if syntax is log4net or nlog -> convert into LW syntax (file_text_reader)
- care about ';' -> min size
- msg[''] -> works
- test syntax dialog -> recognize it correctly (nlog / log4net)


1.8.11
- dropping a .config file : works
- dropping a log file
  - automatically parse for .config files
	  - see if nlog or log4net
	  - first look for .exe and .exe.config files
	  - look for config files in directory + parent + parent


1.8.10
- edit log settings: can load settings from nlog/log4net config file


1.8.9
- parsing nlog/log4net config files works
  - it recognizes and fills file name, syntax, database details


1.8.8c
- nlog syntax pattern - recognized correctly


1.8.8b
- log4net syntax pattern - recognized correctly


1.8.8a
- moved tests into their own dir
- added scheletron for parsing nlog/log4net syntax (pattern)


1.8.7e
- reading from database works
- tested also tailing the database, which works


1.8.7d
- if file name ends in .db* -> open the Log Settings with database selected + assume sqlite
- see if db already exists in history -> if so, use that


1.8.7c
- connecting to database (Edit Log Settings) works
  - also added code to handle sqlite and oracle databased
- I allow mapping from the database columns to Logwizard columns
- I allow testing the connection, so it's really easy to connect to a database


1.8.7a
- created test program for logging dummy data using nlog. works for sqlite databases as well.


1.8.6
- hm3 syntax -> separate via '|syntax|'
- fix for #79 (.csv and .svg files)
- column names - updated correctly even on first load
- show errors in status bar: if any
- handle "Access denied" file error (show error in status bar, try again in 5 seconds)
- handle the case when user is drag and dropping a Windows Event Log (show an error)


1.8.5
- fixed #78 Syntax not working with pipe symbol separators 
- added "If line starts with tab, assume from previous line" log setting (for line-by-line files)
- fix: when changing the syntax, and then updating column positions, they were ignored at next restart
  (because history and text_'s settings got de-synchronized)


1.8.3
- column formatters
  - categories: - Column: Name -> Value


1.8.2
- small fixes


1.8.1
- to release to public
- ctrl-shift-b for changing number base (to be consistent with ctrl-shift-a)


1.7.41
- added samples to menu (Open Log Sample)
- added tips
- while loading categories -> hide the list + show "Loading"
- improved category colors


1.7.38
- fixed bug: sometimes we would show the wrong line color for rows
  because we could end up using a line's existing font (not its copy), thus we could end up modifying it, and all references to that font
  would then point to the changed font


1.7.37
- fix: showing all lines (ctrl-alt-l), then going back to just view (ctrl-alt-l) which shows just a single view while real-time
       new lines are shown incorrectly (because I had cached them)
- test logwizard on TN2 - while it starts/runs - works as expected
- retest on event log -> see i don't show date by default
- fix: #67 retest samples on clean config
	

1.7.36
- added selection + bookmark icons by default


1.7.35
- fixed #42 - syntax not working
- fixed #73 - by default, I should not show Date column


1.7.34
- fixed #17 Look around - make it configurable
- bookmark - don't show in any color


1.7.33
- made the current selection much lighter than before - so that it interferes least with rest of our coloring


1.7.32
- solved: #70 line : show the selection with an image (this will make things easier)
  - added bookmarks as well


1.7.31c
- solved #54 - selection: don't double-dark it
- categories #69 : finally works, together with all other formatters


1.7.31b
- categories formatter
  - works, but the background for the text is not correct (it's always white)


1.7.31a
- categories:
  - category formatter added (not tested)


1.7.30
- categories:
  - synchronize the category names from the categories list into the Preview (the Category column)


1.7.29
- categories
  - cursor -> hand on color selection
  - click 
    - show color picker
    - on ok -> set color + update + generate event (something changed) + update preview
  - selecting a certain row -> update preview so that selection is of that color
    -have a max number of items (so that if i have too many -> show something or so)


1.7.28
- column formatter: 
  - format number if any part of the number is already formatted -> don't do anything
    - only if frmo a smaller part than the whole text


1.7.27
- Actions menu: show it depending on mouse position
- all forms: changed to dpi (auto scale)


1.7.26
- column formatter: 
  - abbreviation : tested removing parts completely - works now	
  - logview filter changes? -> clear format cache


1.7.25
- column formatter: abbreviation works AWESOMELY
  - you can use subexpressions: - https://msdn.microsoft.com/en-us/library/bs2twtah%28v=vs.110%29.aspx#named_matched_subexpression
  - allow toggle between shortcuts ON/OFF (ctrl-shift-a) -for some strange reason, ctrl-alt-a doesn't work. Very likely the smart edit (richtextbox) is using it?
  - formatting specified in ["blabla"]
  - example: 
		- abb.find=\{x=(?<x>\d*),y=(?<y>\d*),width=(?<w>\d*),height=(?<h>\d*)\}
		- abb.replace=["green"][["red/bold"]${x},["blue/italic"]${y},["violet/bold"]${w}/${h}["green"]]


1.7.24
- column formatter: tooltip: when hovering a number, show it in hexa, octal, decimal and binary
     - ask formatters for tooltip - different formatters can do different stuff!


1.7.23
- column formatter: if any "number" formatter -> allow ctrl-alt-B to switch between bases (hexa, decimal, octal, binary)
    - override this only for now (non-persistent)
	- clear cache


1.7.22
- column formatter
	- render -> when showing search/typeasyougo increased background -> increase it based on the original background, not the one now (like, when using alternate)
	- fix: column format preview: picture - does not work in preview mode


1.7.21
- column formatters speed improvements
  - multi_sel_idx can get expensive if called multiple times (during UI drawing) -> cached it in log_view_renderer
  - cache: 
    - override print is very CPU intensive - I cached it -> only for log_view_renderer (the other renderers aren't used that ofen, so it doesn't matter for them)
	- see which columns can't be cached (time/date) -> because they compute formatting based on prev text / top row
	- when any column formatting changes -> clear cache
	- typing something -> clear cache
	- searching changes -> clear cache 

Defaults for column formatting:
	- line numbers - a' la intelliJ
	- time + date: show only difference compared to previous (the rest in much lighter color) - default, in blue
	- things in brackets - perhaps show them in slightly lighter color
	- number / strings -> in msg -> show differently (number, string_)
	- level : show as pictures
	- date: no year
	- alignment


1.7.20
- column formatter: allow for pictures (picture formatter)


1.7.17d
- HM3 logs: a new syntax
- fix: open files with fileshare.readwrite access - all over the place


1.7.17c
- column formatter 
  - Edit Column Formatters works 
	- from right click on teh column header
	- saves settings correctly
- Settings: have default column formatting, which can be changed


1.7.17b
- column formatter
  Edit Column Formatters works - even preview works like a charm


1.7.17a
- column formatter : before making list into ObjectListView (from VirtualObjectListView)


1.7.16
- column formatter: solved bugs:
	- bg -> not computed correctly for search text
	- 'e' -> will select too much text


1.7.15
- column formatter: alignment works


1.7.14b
- column formatter: multiline works


1.7.14a
- column formatter: multiline
   implemented, not tested (with alternate/separator as colors)


1.7.13
- column formatter: color_time
  - use 'format' for formatting (instead of 'color')
  - time: allow using the line.time -> allow specifying format: yyyy/MM/dd and so on 


1.7.12c
- column formatter: color renamed as cell + not a helper


1.7.12b
- fix: all project compiles (moved to .net4.5)
- not using gradient at all - it was just an experiment, and with current way of implementing renders, too complicated
- fix: time/date -> use custom font
- fix: alternate doesn't work completely, for all row text
- line: shown awesomely, like in intellij


1.7.12a
- column formatter:
  - alternate bg: allow specifying alternate color


1.7.11
- column formatter
  - regex color works
  - alternate bg slightly works - does not work in all cases - some text is shown in white bg


1.7.10
- column formatter
  - format number works


1.7.9
- column formatter
  - compare_number works


1.7.8
- column formatter
  - time formatter works
  - date formatter works


1.7.7
- column formatter skeletron:
	- special words "lighter", "darker"
	- easy syntax, see column_formatter_array
	- line numbers shown in green-a-la-VS2013


1.7.6
- done: if i add_part something already there -> i need to "merge" that (fonts and such, with the emphasis that what I add overrides what exists)
  - i should be able to merge even several entries! -> basically i need to see that when splitting something between two items -> i should probably merge the text_parts TOTHINK
- done: i need to be able to return it in such a way that i can easily use to print info, wherever (in smart edit, etc.)


1.7.5
- REFACTORING: no more Tuple<int,int,print_info> -> move everything into print_info, now renamed as text_part


1.7.4b
- small doc updates


1.7.4
- renamed history file as .md
- added event_log.md file


1.7.3
- Runtime / svchost -> right click and color them (doesn't work)  -> fixed


1.7.2b
- regex (installation.*ready) not working if case insensitive


1.7.2a
- fix: Microsoft-Windows-TWinUI/Operational - does not work
- read from C:\Windows\System32\winevt\Logs (find it with Environment.Specialdir), sort by latest ones (for Local) - get the latest 100 files or so
- checking it in the list should update the text box
- Test button - test how many entries each log has (read everything, as long as the user wants to - each with its own thread) 
  - should work even on remote machines if password is set
- seeting the lv.List cursor - if over the header, don't do anything (leave as is) - also, see if another form is active -if so, don't do anything
- regex ".*" -> autoregex


1.7.1
- released to public


1.6.31b
- solved #47 filtering / finding (next prev) - show progress 
  - busy cursor when this happens
  - show progress in status bar


1.6.31a
- find first/next/prev happen on a different thread


1.6.30
- generated setup kit - works now


1.6.29
- moved back to .net 4.5 - i want to use async/await keywords


1.6.28
- solved #48 - export to csv - works (tested opening in openoffice + reopening in LW)


1.6.27b
- solved #51 - find: don't load all 1000 rows into preview
  - loading surrounding rows - on a different thread - so that i cna increase the number of surrounding rows


1.6.27a
- made large_string thread-safe
- large_string : cache last lines
- solved #46 optimize string_search when all columns = true (see line.raw_full_msg)
- several improvements to search_form (before moving load_surrounding_rows to a different thread)


1.6.26
- fixed problem in setup kit - did not upgrade everything to latest version


1.6.25c
- retested on empty settings file - works
- event log: sometimes FormatDescription returns null, so we get the description from the .Properties


1.6.25b
+ when selecting something from history, mark it as "last" in the given position (default or custom1-9)
+ when opening history, if in custom position, remember the "last" log and show it as such (depending on what customX I'm on)
- every time i open a log -> that needs to go to the end of last_log_guid
- select a different log (log history) + restart -> does not select the right log at restart


1.6.25a
- not to auto-open the last log by default - #33
- ** tip: Ctrl-H, Enter - select last log**
  (making it easy to open different logs on different custom positions)



1.6.24
- #32 fully solved :  retest event viewer + debugviewer 
  - event viewer: convert computername/username to friendly?
  - note: no need to cache them, since SecurityIdentifier is quite fast

[Caching Cells]

event log:
- after profiling - the bottleneck is to_log_entry. However, seems there's nothing I can do, since doing a Parallel.For did no improvements whatsoever.
  The bottleneck is EventLog.GetFormatDescription. To make things worse, seems it has some global lock inside, and calling this from several threads still yields 
  no performance improvements.

  One other way to improve this is : 
  - postpone reading description.
  - have a thread that actually reads this constantly and fills it
  - create a class line_ex : line, which will cache the description only when requested
    this will be a pretty big change. And very likely, 
	- i'll need another large_string that will deal with the cache as new entries are added
	- i need to make this general, so that I can have other columns that behave the same way (that I would only cache when needed)
	- perhaps I can also have two types of caching: 'bring on request', 'bring on request and on background' (I would have one or more threads filling the cache in the background)
	- probably in this case -> for columns that are cached like this, identify each cell with a unique id
	  the cell will then ask the large_string_cache class for this entry. the class knows how to retrieve the cell (if not already cached)


1.6.23
- search for "110652 1/14/2016 12:45:07.757 INFO Scoping successfully completed for shadowcopy \\?\GLOBALROOT\Device\HarddiskVolumeShadowCopy6." -> too long
             "\\?\GLOBALROOT\Device\HarddiskVolumeShadowCopy6" -> still too long
  profiling: 
  there's pretty much nothing I can do here to improve on it
  One thing I could do is to do the search on a different thread. I don't think this is worth it at this time. May come back on this decision
  at a later time.


1.6.22
- fixed: issue still exists at the end. (small freeze when event logs fully read) - even after 1.6.19a
- open log: go to event log -> not reversed by default


1.6.21
event log
- same event added several times(when not reversed)
  - apparently, two event log readers are created or something all adding to same log -> not sure why 
    - maybe just on Open Log??? (not on opening existing log) -> yup, that is why
	  seems to indeed happen only on Open Log
	  ------ perhaps event_log_reader.create_logs is created several times???

  I have made a workaround to the above, works ok for now. See #43 for a full fix.


1.6.20
- optimized memory consumption on event log
  note: i thought linq was causing lots of memory consumption, but that was not the case
        simply running a GC.Collect() after fully read event log into memory did wonders
		GC.Collect() needs to be called several times several times in order to make a difference
		results: basically memory goes to half of what it used to be


1.6.19c
- search -> ctrl-c - if text selected, use that


1.6.19b
- updated copyright


1.6.19a
- event log : match_list.add_range -> called too many times
   - it was called too many times
   - also, a "file_rewritten" was mistakingly sent after the Event log was fully read (fixed)

1.6.18
- solved #40 -  windows have default icon


1.6.17
- solved #34 don't create file associations (.txt, .zip, .log) by default


1.6.16c
- #39 reverse order -> searching for date/time does not work (ctrl-g)


1.6.16b
- solved #27 date column - care about it when sorting
- note: still a bug : #39


1.6.16a
- date column - include in sorting
- goto -> show visually where going to (like, after 10 lines, before x lines, to date XXX, extra x seconds etc)
- goto date -> works as long as it's sorted ascending (in event viewer, by default it's decending)


1.6.15
- solved #36 : First run - the columns are not shown correctly


1.6.14
- solved #26 : new log with lots of columns - show most of them in Details pane


1.6.13
- REFACTORING: 
 - column_positions are now kept in the log's settings and is accessible to log_view
 - column positions + show/hide information is cached and used next time you open the log


1.6.12
- REFACTORING: created the log_settings_string[_readonly] classes


1.6.11
- setup kit ran for first time -> does not show correctly the logwizard.setup sample (32bit)
  probably because of file-to-setting context


1.6.10
- solved setup issue - error at trying to copy to invalid directory


1.6.10c
- #20 fully solved
  - event viewer: 
    - scroll to last: in reverse -> reverse it (go to top all the time)


1.6.10b
- event viewer: adding events in reverse works (in event viewer/event view log classes)


1.6.10a
- event viewer events read in reverse : old items works
- On Event viewer -> "reverse" should be selected by default.


1.6.9b
- #30 completely fixed
  - highlight all search cells in view
  - highlight all search cells in details pane


1.6.9a
- search.allcolumns exists, is set/saved + used by default
- searching for all columns works in Find dialog
  - it does not yet highlight finds in all columns (it only highlights the msg one)


1.6.8
- #13 - bug: if at the last last visible down + arrow down 


1.6.7
-- bug (old, just needs rechecking to see if it still happens) 
   [note: checked, does not happen anymore]
   : C:\john\code\buff\344\TNLogs-DESKTOP-6JGLCS9-damie-635833594984576357 -> hotkeys shows 0 and is hidden
   -- this seems to be related to this tab? i don't see the edit here, and i simply can't make it work (on a different file -C:\john\code\buff\348\T175745-Reports 2015.11.19)
      - after restart, it works
	  - i believe here the issue is: if i show history then escape -> focus will remain on the hidden history combo - i just need to reset focus to active pane
	  - it's weird - sometimes works sometimes not -> seems ot always work only on the view that originally had focus, but not on the others
	  -- "hotkeys" tab always seems to be marked as "has new items" even if i traverse it


1.6.6h
- debug print -> rename as Debug View


1.6.6g
- #9 - bug: type as you go + if searching works for something, but it's only visible in the description pane, i will show that by showing all line in the view in a 
slightly different background (so that the user sees his search is successful)


1.6.6f
- if current col not visible, update the smart edit so that it points somewhere


1.6.6e
- moved is_visible/col_width inside olv_extensions


1.6.6d
- #7 -- bug - if i'm on the last char, and want to select starting from there to the left, it does not work


1.6.6c
- #6 - click to select a word -> allow turning this off


1.6.6b
- #5: add a horizonal scrollbar (make Msg not "occupy remaining space") -> allow a checkbox


1.6.6a
- #4 : line numbers -> allow turning off


1.6.5b
- moved bugs/features issues into github


1.6.5
- logwizardsetupsample -> into samples
- samples -> into personal directory (...Documents)
- settings kept in %appdata%\\..\\Local instead of Roaming (#3)
- double checked - nothing is written into Roaming (by setup kit or by LW)


1.6.4c
- readded build status


1.6.4b
- readded .sample.log files into github


1.6.4a
- added gitattributes file


1.6.3c
- github interim versions (not beta nor stable) -> those ending in (interim)


1.6.3b
- made test_ui compile
- removed compile warnings


1.6.3a
- fix for loading AllProcesses.log crash


1.6.1
- to be released to public - with Event Viewwer and Debug Print


1.5.21
- redo the HOME page - perhaps more screenshots, etc?
  - think about features etc.
- github - delete "intro" page


1.5.20
- first_available_toggle_custom_ui -> if at position 0 nothing, return that
  like, i can open event viewer, move it to position 1, and then when i open "New" -> it should automatically go to "Default"
  -> when opened via "New", perhaps by default I should not load any log?
     -> eventually show tip "Use Ctrl-h to show Log History or Ctrl-O to Open Log"
--done: ctrl-1 should take me to position 1 if it's already there -> just double check
   --> to think of an equivalent for ctrl-tab / ctrl-shift=tab for windows - maybe ctrl-0?
- if not full log -> show in brackets in the header -> number of entries
  also - check if number of filtered entries = entries -> in that case, no need to show "entries" (we already have it)


1.5.19
- done: some tip about "Open Log" or "Show History".... (or two tips maybe?)
- done: should see if i should open the "details" pane by default (perhaps only first time? after that, the user should know about it)


1.5.18
- event log: can read in reverse as well
- event log: since in reverse, gototime should be different


1.5.17
- fix: event log : try using FormatDescription again


1.5.15
- msg_details -> show it if the message spans over more than one line
- fix: event log: going to history then pressing Esc -> will somehow force a refresh which forces everything to reload -> not cool
- event log : details pane : should show message


1.5.14
- fix:event log: "Log" column is not filled
- event log: fix: takes too long to load
- fix: event log: 
  the title is not correctly
  at status - log name is wrong (should be "Local Windows Event Log - Sytem, Application")
  while loading - show progress in bold + each type of log's progress in bold
- event log:
  dump progress, as we're loading the items (like, how many entries we have)
  --> this actually happns, double check it's generic


1.5.13
- moved everything in src/ directory, so that the https://github.com/jtorjo/logwizard looks cleaner


1.5.11
- fix: when showing the sample (after the setup kit) -> after running second time, it still shows the setup sample
  - test so that after run first time (empty lw_user.txt) , when run second time, it should be totally empty! (that is, see "Drop it like it's hot'")
  - perhaps when loading history entries -> ignore the Logwizardsetup ???


1.5.10h
- type-as-you-go - care about columns that are only in description pane as well
  + care about the columns that are visible in the view

		  
1.5.10g
- fixed bug: doing "arrow left" (edit mode) to go through all fields would generate an assertion failure
  (because we would actually show the "View(s)" column with size 0 on the current view)


1.5.10f
- once i change the description template -> save it and use it for log/context.
- description: watch for resize of splitDescription splitter, and save it


1.5.10e
- save column widths / positions in app.inst.description_layouts_ -> i only need the splitter distance
  - have a min splitter distance of 100 for each
  - monitor for changes, and see about ignore_change


1.5.10d
- log_view control: when showing any multi-line text, ignore any trailing lines (start + end)
  - testing (debug) -> split each line at 15 chars
  + if there's any custom-color text:
    - if we have something from type-as-you-go, select that specific line
	- if we have something from any running filters, just select the first line that has something and show it
	- if lines before/after need to show visually (like, show the "Paragraph" sign)
	  - there should be a way to turn this off
- allow description control to be resizable


1.5.10c
- description control
  - on an item: need to update description control + the text should be multi-colored


1.5.10b
- description: tested on release mode: good news, resizing/moving is not CPU-consuming
- fix: when used first time, description control shows thread + msg. should show only msg


1.5.10a
- implement toggle details 
  - added it to logwizard form
  - when turned on, the other msg_details need to be hidden
- IMPORTANT:
  adding the details control on the Logwizard form slowed down resizing/moving a LOT on debug mode
  my take is that it's because of the many splitter-container-inside-splitter-container, and perhaps it's combined with the fact
  that they are all using Dock=Fill.
  also, description_ctrl has 6-embedded-into-one-another splitter controls. 
  I'm hoping that this won't matter in release (about to test now)


1.5.9g
- description control - ALL WORKS LIKE A CHARM


1.5.9f
- description control
  - up/down/left/right buttons work


1.5.9e
- description control
  - can change no of rows
  - can edit whether multi-line, line count
  - can hide/show columns
  - can edit a certain column


1.5.9d
- description control: 
  friendly names for default aliases
  solved minor bugs
  label width computed based on aliases


1.5.9c
- description control : set_aliases works


1.5.9a
- partially implemented description control
- refactored aliases - so that the column names are set as soon as we know them (within aliases)
  - thus, when i want to know a friendly name from aliases, I don't need to know the column names


1.5.8g
- fix: bug: in find preview - i don't show the columns correctly (don't compute correctly which columns to show/hide)


1.5.8f
- fix: history : opened log does not move log  to end
- removed: syntax_type=edited_now


1.5.8e
- debug log: when the full log is empty, we get lots of refreshes and stuff
  - note: test on another type of log -> debug really messes up with VS


1.5.8d
- debug log: when the full log is empty, we get lots of refreshes and stuff
  - partially implemented


1.5.8c
- sometimes when switching between files in history, syntax is not updated correctly
  - there was no bug
- done: the active view: update_x_of_y() header title should only contain the name - so taht when i update real time i don't cause lots of refresh


1.5.8b
- open log -> allow browsing for file (after browse, adjust the filetype)
  - only for open, not for edit


1.5.8a
- fix: history_select -> does it work for **new** files?


1.5.7b
- event log: get the correct message
- event log reader/debug print -> need to have the right defaults (column names, etc)
- history : friendly names for event log + debug_print
- rich label -> tooltip -> show everything (in case it's multiple lines)


1.5.7a
- event log - test with Microsoft-Windows-TWinUI/Operational -> see if i can get correctly number of items
  - works now
- event log - shows the log name as well
- event log -> for passw -> do NOT save it
  - if user needs to set password -> need to show settings
- event log: tested getting logs from another machine - works
 

1.5.6x
- fix: the full log does not update correctly for event log


1.5.6t
- done: event log - need to show something - while loading - at least progress? (i should know up-front how many items are in total)
  - bug: the full log does not update correctly for event log


1.5.6s
- allow ctrl-6 to ctrl-9 hotkeys
- CHANGE Hotkey: ctrl-shift-o -> Open in Explorer; ctrl-o - open log
- fix: open log -> doesn't remember that i opened a debug_print log next time it's run
  - same for event log


1.5.6r
- open log: event log on a remote pc - works, and also validates the selected event logs
  - note: enumerating the logs from the remote machine does not work, no matter what i do.


1.5.6o
- open log : debug -> saves settings correctly
- open log : event log 
  -> recognizes non-default logs correctly , such as "Microsoft-Windows-TWinUI/Operational"
  -> made it possible to login to a remote pc - can't test right now'


1.5.6n
- create backup of original settings file -> just in case we mess it up
- at this time, I can select a new type of log (like, Debug)
  - however, it's not saved into settings


1.5.6m
- refactoring so that I can create new types of logs easily (event log/debug), and have settings saved correctly
- saving settings (per each log) - so that even if clearing history, we'll still have the file settings
	- log file -> guid (so that even if i delete from history, it will still point correctly)
	  on_new_file_log -> createtextreader
	- context syntax + aliases -> i should not take them from the current text reader's settings - since they can be overridden when the text_reader is created


1.5.6l
settings:
- guid -> settings ALL THE TIME 
- history -> keep guid


1.5.6k
- HUGE CHANGE: refactoring: sharing settings between text_reader, log_parser and history


1.5.6j
- event log - allow selection of logs (settings) - not finished


1.5.6i
- event log - allow subscribing to more events


1.5.6h
- event log: allow filtering by provider


1.5.6g
- log wizard from several event logs in parallel works


1.5.6f
- updated history.txt


1.5.6e
- debug string logger works!!!


1.5.6d
- event log roughly works


1.5.6c
- refactoring, to allow reading from event viewer


1.5.6b
- updated Logwizard intro on github again :)


1.5.6a
- updated Logwizard intro on github
- show "Tip" in bold


1.5.5 (final)
- status : can now show tips


1.5.5b
- refactored status control
  - statuses kept in status_ctrl (so that it's easier for me to show tips)


1.5.5a
fix
- bug:	I opened a file, A.txt, in LW. Then I copied that to A-copy.txt.  So I have A.txt and A-copy.txt. Then deleted A.txt. So, LW now clears the display for A.txt.
		So far so good. Next, I renamed A-copy.txt to A.txt. This rename is a kind of file update. So, I expected LW to update the display, but it does not. Even Refresh doesn't work.


1.5.4 (final)
- settings: edit from right click


1.5.4h
- edit settings -> removed not needed controls from source pane


1.5.4g
- edit settings works like a charm!
done:
---------- for non-file logs (like, event log, db, sockets?, outputdebugstring)
 ***- this needs to exist for each type of log - even files (specify type: line-by-line, log line, xml, csv etc.)
 - i need to have extra options for each (like, outputdebugstring -> filter by application name(s))
 ------------ note: i do have them now, in string_as_settings
 - after showing dialog, need to find out if settings change require restart!


1.5.4f
- edit settings - partially works 
  still to do : test + allow editing syntax 


1.5.4e
- showing columns: when changing from one log to another (with very different columns),
  make sure we show columns that were otherwise not available to the former log


1.5.4d
- showing columns - now works correctly
  - when right clicking to hide/show columns -> only the columns that actually have values will be shown


1.5.4c
- showing columns - does NOT fully work



1.5.4b
- refresh_visible_columns - if from the syntax, i can find a column and it's empty, mark it as ' ' or something - so that it's different than "" -> so that i show that column
  - basically, if i find it in valid column names, I show it


1.5.4a
- fix: some hotkeys did not work anymore after moving actions into "What's Up?" button
- font (selecting font): enable ScriptsOnly
- font (settings): allow showing variable fonts as well (NOT recommended)
- settings: allow showing beta updates; if unchecked, only stables ones are shown (enabled by default)


1.5.3
- add/del view , sync view buttons -> hide them by default - they should be visible only if the mouse is around them (on the y axis)


1.5.2g
- moved every former command from lower pane into the "What's up" button


1.5.2f
- implemented animated button - now, we bold a single char


1.5.2e
- put status inside low pane 
  - toggle status/title work correctly


1.5.2d
- status control - added to LogWizard


1.5.2c
- status control - works AWESOMELY !!!


1.5.2b
- status control - before removing the idiotic richtextbox


1.5.2a
- github release: if stable is later than beta, just show stable


1.5.1b
- retested getting release info from github 
- fixed small bug


1.5.1
- retested getting release info from github 
- released to git


1.4.9i
- getting release info from github - works like a charm :D
  - show in status
  - show in about dialog, like a boss :D


1.4.9h
- added Get Latest version messages


1.4.9g
- targetting .net4 (as opposed to .net4.5)
  - note: i used to target 4.5 for allowing bigger than 2Gb objects - this may not be needed anymore?
  - in case i run into issues, i may go back to 4.5
- getting release info from github (not complete yet)
- added fastjson (http://www.codeproject.com/Articles/159450/fastJSON)


1.4.9f
- ctrl-tab/ctrl-shift-tab -> for navigating the tabs
- ctrl-right/left -> for word selection
  - ctrl-shift-arrows works correctly now


1.4.9e
- bug: shift -arrow down - does not work, it goes to end.


1.4.9d
- pgup/pgdown/etc. - -> don't do any low level scroll whatsoever - i know the top index to be shown -> just ensure_visible + select item + refresh!


1.4.9c
- fix: escape() - should re-add existing edit text(otherwise, former selection is shown on edit)
- bug: find enter something new, like "sit". press Enter. It will end up opening the combo (instead of taking effect) - this is only a problem in "full log"
  - same stuff happens on ctrl-h on "full log"
- search: if already exists, just add it to end (that is, the user manually types an existing search - don't clutter the history)


1.4.9b
- fix: resizing logview -> update UI of edit - same for moving!


1.4.9a
- edit toggles - when clicking something, don't hide the menu (like in the columns menu)


1.4.8p
- retestd on my usual log


1.4.8o
- aliases-> show in column title names
  - ctx1=something
  - ip=ctx1{something}


1.4.8n
- aliases -> they match correctly (those that by default don't have any match), if user edits them
  - I avoid having two log columns matching to the same logwizard column
- edit aliases
  - need to pass the column names when editing
  - help: as default string, just have something like each_name=[something] (for names that are not recognized)
  - show in help the types of aliases
- if col=lw_column, the remainder of the columns must match to the remaining 
  if suit_1=ctx1, the ctx can not be used by something else!
- add aliases as well
	-> where do i keep them? context, file?
	  - both - if not found in file, take from context
	    - note: this is implemented in 'factory' class - i just need to make sure they get saved correctly, when user modifies them


1.4.8m
- moved go_to_linetime into lw_common


1.4.8l
- parsing csv files works
- xml: set the column names as well


1.4.8k
- parsing from xml file - works


1.4.8j
- aliases: If nothing is set, everything matches to ctx1, ctx2, ... and the last one matches to msg.


1.4.8i
- refactored file parsers (xml,csv and file_part_on_single_line)


1.4.8h
- simple logger generates xml now.


1.4.8g
- synchronize colors - sync just with the current view by default
- created simple project for simulating xml logger


1.4.8f
- added xml and csv parsers - NOT TESTED


1.4.8e
- parser for line "xx: yy" and empty line is end-of-record - works
- aliases work (converting alias name to info-type)
    - allow for aliases based on column index like _0=Date, _1=Time , and so on - both types of aliases need to work
- done: add aliases as well
	- i keep them in both context/file - if not found in file, take from context
	  - note: this is implemented in 'factory' class - i just need to make sure they get saved correctly, when user modifies them


1.4.8d
- more coding, nothing finished


1.4.8c
- extra testing, saved minor bugs (saving settings)


1.4.8b
- storing settings - save context dependent settings

1.4.8a
- storing settings - loading settings works
  - this allows us to store any settings - in context and/or log - regardless of logs


1.4.7d
- allow FindFirstChangeNotification API to monitor for changes
  - make as setting (disabled by default)


1.4.7c
- when monitoring real-time + on last line
  - don't show it with a different color (the selection color) - it can be distracting
  - we should show it on the normal color only if no updates for a while (like, 5 seconds or so - otherwise, show it with normal bg)


1.4.7b
- filter: new lines -> only when no of lines changes or file rewritten
- generate "new lines" events every time new lines are added to a view


1.4.7a
- log view: get event on file rewritten as well
- fixed bug: sometimes some "new lines" events did not get triggered


1.4.6
- added asyncfilelogger


1.4.4b
- generated 32-bit and 64-bit setup kits


1.4.4
- solved bug: regexes not correctly searched
- view containing all lines
  - allow excluding lines (this should work at all times)
  - the "ONLY" should be shown only when there are no "include" filters at all
- fix: bug : toggling "show all lines" on uk_small does not work (doesn't show anything)
  - bug occurs only if full log was never shown (i would need to force it in this case)
  --> the fix will always refresh the full log
      we always refresh the full log - since we allow toggling "show all lines" in all views, we need the full log to contain all lines


1.4.1
- tested in release - works like a boss :D


1.3.36i
- computing matches on a different thread - showing only a few results, so that the refresh is instant


1.3.36h
- computing matches on a different thread - however, still too much time spent on showing items


1.3.36g
- search last view names: hold only last 15 last views


1.3.36f
- fix: when search results -> fg matches bg - text not shown


1.3.36e
- fix: when dropped down -> if i change to a regex -> it will update the text to what is shown in the combo instead of the real regex


1.3.36d
- done: implement all_searches_cur_view_first
  - searches from current view shown in bold


1.3.36c
- history saved as expected
- done: friendly regexname


1.3.36b
- refactored search_for - save/load inside there, saving history logic moved into search_form_history


1.3.36a
- refactored search_for -> out of scope


1.3.35f
- find preview: results shown in different colors. awesomeness!


1.3.35e
- find preview - preview works - only rows matching are shown


1.3.35d
- find preview: the preview rows are loaded correctly
  - even the column order + widths is preserved!


1.3.35c
- no need for help_form anymore


1.3.35b
- refactoring: moved most forms into lw_common


1.3.35a
- filter regex: RegexOptions.Singleline
- search : reuse default_search


1.3.34e
- saving column positions works
  - works even if you choose to save them for all-views, or just for a specific view
  - at this time, saved in the context-ui


1.3.34d
- fix: if just changing width of a column - need to notify the rest


1.3.34c
- load/save of columns + saving them to all views works like a charm
  - "apply to currnet view only" also works
- removed toggle_show_msg_only - we now have way more advanced way of showing/hiding/resizing columns
- done: refactoring of visible_columns_refreshed


1.3.34b
- load/save of columns + saving them to all views seems to work
- BEFORE refactoring of visible_columns_refreshed
  - it should happen noly for the full log -> and as soon as we have it, refresh everything else


1.3.34a
- right click on column header 
  - allows hiding/showing columns
  - allows moving columns to left/right
 = IMPORTANT - see if changing DisplayIndex affects position in the AllColumns -> that would be rather bad
   - tested: it does not happen

 
1.3.33h
- fixed small bug when New pressed first time


1.3.33g
- switching to a position that is "virgin" -> copy from existing position
- when pressing "New" -> if new position is "virgin", copy from last position + make it a bit lower, so that both are visible


1.3.33f
- done: must make sure we don't allow changing the position of a LogWizard form to an existing custom position from another LogWizard form


1.3.33e
- "New" works -> it will take you to the next available custom position
  - however, must make sure we don't allow changing the position of a LogWizard form to an existing custom position from another LogWizard form


1.3.33d
- position UIs - allow up to Ctrl-9
- synchronize context combos across LW forms
- LogWizard.on_context_changed - disable all but first form having a specific context


1.3.33c
- removed ui_context.auto_match - not used anymore


1.3.33b
- font: allow changing it


1.3.33a
- text in msg_details - can i center it just a bit?
  - of course we can : awesomeness :D


1.3.32g
- fix: bug: next/prev bookmark does not sync with full log


1.3.32f
- bug notes export: they are not sorted by id when expoted
  note: might happen only first time you add the notes (if you restart app, it will work correctly); really minor


1.3.32e
- fix: bug: selecting something with arrow right, and then pressing arrow left will select an extra char from left instead of acting as backspace


1.3.32d
- fix: bug: allow selecting text with the mouse (not just shift-arrows)
- fix: bug: selecting a word and pressing f3 will take you correctly, but will select the former selection as well


1.3.32c
- smart edit: can handle mousewheel - awesomeness :D


1.3.32b
- can handle mousewheel - http://stackoverflow.com/questions/7852824/usercontrol-how-to-add-mousewheel-listener
  - however, not exactly what i want - about to tweak it now


1.3.32a
- bug : clicking with mouse -> does not select the right column (when clicking on the msg)


1.3.31i
- fix: changing file -> the smart edit does not update
  IMPORTANT: this isn't the best way to do this - we should have an event to be triggered when the log has changed and the filter has yielded some results
  

1.3.31h
- fix: bug: seems that after monitoring (live) for a file, if i drop another file, i will get an infinite number of "new lines" events
				(0): 02:20:22,864 9760       DEBUG - [log] new lines for C:\john\code\tableninja-v2\TableNinja2\TN2\bin\Debug\TableNinja2.log
				(0): 02:20:22,865 9760       DEBUG - [log] new lines for C:\john\code\tableninja-v2\TableNinja2\TN2\bin\Debug\TableNinja2.log
				(0): 02:20:22,865 9760       DEBUG - [log] new lines for C:\john\code\tableninja-v2\TableNinja2\TN2\bin\Debug\TableNinja2.log
				(0): 02:20:22,865 9760       DEBUG - [log] new lines for C:\john\code\tableninja-v2\TableNinja2\TN2\bin\Debug\TableNinja2.log
				........

1.3.31g
- fix: when going to view X(realtime), there's something there, goint to view Y, when X gets updated (new lines) -> it does not go to the end
- reviewed license - gpl3 is totally ok


1.3.31f
- fix: drag drop a file from a different context -> not all view names (in tabcontrol) are changed 
  (probably the current one is not updated correctly? or the first one?)


1.3.31e
- rename view - if name already exists, append suffix to it
- fixed: bug: when the source pane is shown, we sometimes end up showing something wrong in the view name


1.3.31d
- removed spurious usages of ensure_we_have_log_view_for_tab
  - we should pretty much use it only when context gets changed (or new views get added)
- renaming a view -> only via right click (not on toggle Source pane), and only called when rename is complete (not on each typed character)


1.3.31c
- keep latest 20-30 logs


1.3.31b
fixes:
- log the indexes when adding to largestring - so i can fully repro
- on tn2/debug -> msg column not shown on full log; also, file:line shown after msg on current view
- bug: on debug/tableninja2.log -> we don't show all lines - we're pretty much behind
  - note: it shows we read all lines, but it does not update -> perhaps item_count related?
  - note: i was watching "bet" tab, but full log did not update correctly either
    - to test with tn2 , and betting on lots of tables
  - note: it seems we entered an infinite loop - but not sure where?


1.3.31a
- made msgcol minwidth = 100 
  rationale: otherwise, when view would be too small, the msgcol would end up being totally hidden
             the problem with that is that after reshowing the view to a biggger size, the msgcol would remain hidden
			 -> we don't want that


1.3.30
- fix: see if i can rather quickly find and fix the OLV rendenring issue


1.3.29g
- fix: tn2 bet tab - select preflop, set match color , it will somehow override the color
  (same happened for "process")
- fix: fg/bg: allow changing it (bug: fg does not work)


1.3.29f
- moved filter_line outside filter_line scope


1.3.29e
- avoid using hard-coded colors - especially in log view


1.3.29d
- if line from full logs but not from current view (matches.Count = 0)
  - don't show Filter >> "Set/Change Color" menu
  - don't show Filter >> "Exclude" menu


1.3.29c
- if current view has NO Filtters
  - Include ONLY Lines containing/starting with


1.3.29a
- if line from full logs but not from current view (matches.Count = 0)
  - Include Lines menu


1.3.28f
- fix: when reselecting previous selection -> keep its relative position as well (for instance, if it used to be the 5th shown row, preserve that)
  - of course, preserve it only if possible - for instance, after filtering, we could end up having only 2 rows above, thus can't show as 5th


1.3.28e
- if no selected text/no find -> use the current line to filter by (filter by all filters containing that line)
  - if on a filter line -> use that
  - fixed issue when run on full log


1.3.28d
- if no selected text/no find -> use the current line to filter by (filter by all filters containing that line)
  - if on a filter line -> use that
  - still a bug when filtering on full-log (shows nothing)
- *** replaced .Index with fixed_index()


1.3.28c
- show a status message : "Filtering by ..."


1.3.28b
- toggles 
  - show them visually in "Toggles" menu + update "Filter..." text (based on existing search -> Filter by [word]/ by [search] / by current line)


1.3.28a
- toggles show-full-log -> save them per view 


1.3.27c
- on full log - don't allow any toggling (even though theoretically it could be possible)


1.3.27b
- when toggling: disable the log_view + show "hourglass" cursor
  - while disabled, ignore any toggling of the above (check for lv.Enabled)
- done: end of refresh on teh other thread -> refresh log view +
  - todo: after the user has done any toggle, i need to preserve the former selected item (go_to_closest_line)
- lowlevelsroll : freeze/unfreeze?
  note: not needed anymore = the issue with changing the colors; right now, works like a charm


1.3.27a
- fix: i have to stop using match_at (since it's filter-dependent; or, have it return model.item_at)


1.3.26j
- implementing allowing toggles for view - step 10
  - fg/bg -> when outside of our filters, use gray


1.3.26i
- implementing allowing toggles for view - step 9
  - full log - colors are updated real time- much much better than before!


1.3.26h
- implementing allowing toggles for view - step 8
  - changed log_view.update_colors_for_line so that I can use it directly from match_full_item


1.3.26g
- implementing allowing toggles for view - step 7
  - toggling "current filter" tested and works


1.3.26f
- implementing allowing toggles for view - step 6
  - toggling "show full log" on/off works like a charm (almost :D)


1.3.26e
- implementing allowing toggles for view - step 5
  - using item_count instead of filter.match_count
  - **** there's a bug at this point: nothing is shown in the views
  - **** i have to stop using match_at (since it's filter-dependent; or, have it return model.item_at)


1.3.26d
- implementing allowing toggles for view - step 4
  - toggling skeletron created
  - note: at this point, i need to recompute how i go to the max. number of items in a view (since it's not filter.match_count anymore)


1.3.26c
- implementing allowing toggles for view - step 3
  - reimplemented list_data_source -> however, just realized that line_indexes_ should be a hashset (still todo)


1.3.26b
- implementing allowing toggles for view - step 2
  took match_item, match_full_item, list_data_source out of scope


1.3.26a
- implementing allowing toggles for view - step 1 
  (before moving match_item to outer scope)


1.3.25
- removed log4net.xml
- compile log4net in release all the time
- log4net : in debug mode, don't log to file


1.3.24
- bug: click Test -> it will show the old syntax - not what we've computed (overridden)


1.3.23
- log_view: column width - hide columns with IsVisible property (needs RebuildColumns() !!!)
  - i want this so that user can resize, and i should be able to save this
  - done this for test_log_syntax form as well
- fix: bug : click Test - when pasting - i should check for any type of enter not just \r\n


1.3.22
- log4net - use original version


1.3.21
- added log4net - an OLDER version
  - it's so AMAZING how newer versions seem to mess things up :D
  - the problem with the newer version - i would change the dir to %appdata%\logwizard, init logging, but the log file would be nowhere to be found
    it would probably try to write to Program Files, EVEN THOUGH I CHANGED THE CURRENT DIR.
	So, this old version works
	- And that my friends, is how your hair slowly turns LightGray...


1.3.17
- renamed objectlistview.dll so that it doesn't clash with an existing install

1.3.16
- encoding: if not found by parsing the header of the log, use the system default


1.3.15
- removed signature from objectlistview


1.3.13
- generated setup kit

1.3.11e
- fix: remember the log syntax, once the user changes it


1.3.11d
- fix: bug: refresh_visible_columns shows all cols in view_1 for allprocess.small.log


1.3.11c
- parse new time
  $time['[',']'] $ctx1['[',']' $ctx2['[',']'] $ctx3['[',']'] $ctx4['[',']'] $ctx5['[',']'] $msg|$time['[',']'] $ctx1['[',']' $ctx2['[',']'] $ctx3['[',']'] $ctx4['[',']'] $msg|$date['=> [D/T=','_'] $time['',', '] $msg


1.3.11b
- testing viewing all allprocess.log file - step 2
  - recognizing all enters correctly


1.3.11a
- testing viewing all allprocess.log file - step 1
  - no more 100% cpu on allprocess.log file


1.3.10
- initial version of advanced string splitter (not used yet)
- added (c) where needed


1.3.9
- filters - when refreshing, don't remove old lines and add new ones - instead, do a replace
  this is especially awesome when adding a filter that just changes the color - thus, it's seen instantly, no flickering or anything
	

1.3.8d
- refresh_visible_columns - show the correct info even if less than 10 lines


1.3.8c
- tested showing $thread - works now. Note, the TN2 syntax i wanted is this:
  $time['',' '] $thread['',11] $level['','- '] $msg


1.3.8b
- added $thread and $ctx4 - $ctx15  (in filter_line)


1.3.8a
- added $thread and $ctx4 - $ctx15 (in parsing line syntax + log_view)


1.3.7b
- removed nuget objectlistview


1.3.7a
- added objectlistview 2.8.1 library as source code
  Rationale: to possibly find the render bug, i certainly need to see the OLV source code


1.3.6d
- after set useoverlays to false - bug did not dissapear


1.3.6c
- set UseOverays to false - to see if bug related to weird surroundings of cells dissapears


1.3.6b
refactoring code for parsing logs so that we can easily add new parsers (like: xml, db, etc.) - step 2
- initial testing works


1.3.6a
refactoring code for parsing logs so that we can easily add new parsers (like: xml, db, etc.) - step 1


1.3.5b
refactoring so that we notify filters much faster of real-time changes - finished


1.3.5a
refactoring so that we notify filters much faster of real-time changes
- the log_line_parser is notified of new lines via windows event


1.3.4
- using http://www.codeproject.com/Articles/17201/Detect-Encoding-for-In-and-Outgoing-Text for finding out the encoding of the text
  (works like a charm for Korean)


1.3.3
- .samples.log files - re-marked as "Content"


1.3.2
- making setup kits for public release
- fixed but at replying to note


1.2.29
- ipmroved refreshing by A LOT - basically, don't reload the file unless truly needed


1.2.28
- notes ctrl - show del lines -> show del notes!
- updated setup sample to be more user friendly


1.2.27
- updated logwizard.txt to allow for the .sample files


1.2.24
- fix: bug - adding filter manually would select two rows
- added sample - as .sample + ignored (.gitignore) -> otherwise, github would choke
- added logwizard.sample as well


1.2.23i
- rename view - works
- rename view -> allow backspace


1.2.23h
- right click : filter gotofilter: other view containing this line


1.2.23g
- right click : filter goto filter: edit filter matching this line


1.2.23f
- right click : filter goto filter/filters matching line


1.2.23e
- filter: have an option (default= true): whether to show each row in the color/match_color of the filter
  - if both found, use color


1.2.23d
- when changing color - when the filter also has oher info (such as, match color) - we need to just UPDATE it (preserve what was already there)
  ---> take all lines, remove color/font lines - trim() them on start -> then - if found only in old, append it
  ---------> merging - do it internally in filter_row - much easier to maintain - assert they have the same id + append_to_existing_lines


1.2.23c
- fix: bug: right click menu: changing filter color (of an existing filter) sometimes messes up rendering completely - maybe an extra refresh bowould be in order?
  - done: have extra refresh 100ms later


1.2.23b
- fix: bug: search (find, find next, find prev) - need to synchronize with full log
       same thing when typing and moving ahead/below to a different row


1.2.23a
- fix: bug - i have two filters - first matches color, second matches match-color(+apply to existing lines)
  - i need to make sure both are applied (first one - color of line, second one - the match color)


1.2.22b
- add comment ## specifying the name of the filter -like 'any line containing blabla'


1.2.22a
- fix: bug: (seems it's not apply to existing lines/???') - # // DONOT CHANGE this line -color  #Process
$msg startswith Process
match_color #9F00FF
-- this when added to Init/exit messes it up (it shows) all lines instead of just the filtered ones

- change color -> need to be "apply to existing ilnes" filter
- fix: pressing esc to hide details would end up showing them again in a few millisecs


1.2.21
- fix: bug: release -> alt-f sometimes beeps and does not work properly (same thing for alt-n)
  - it may have to do something with richtextbox shortcuts???
  - maybe because i'm handing it in keydown instead of keyup????


1.2.20d
- menu: most filter actions work
  - need more testing


1.2.20b
- menu: all actions (except filter actions) work


1.2.20a
- exclude lines -> no need to specify any color, we're excluding
- can now show a dialog when selecting a filter menu (not finished)


1.2.19n
- skeletron for menu dealing with filters -> actions for setting filters are in place


1.2.19m
- on a new view started from scratch -> see that in log_view, I don't think it's full-log!


1.2.19k
- press ESC on dropdown works


1.2.19j
- made clicking more accurate (when selecting word)


1.2.19i
- click -> select full word -> care about any delimeter
  -> if clicked passed last char -> don't select anything


1.2.19h
- bug: clicking on list is interpreted as right-click


1.2.19g
- menu: compute - see if it's got enough room to show all items - if not, adjust


1.2.19f
investigated, and the problem is only in debug mode - in release, it's instant. Thus, no problem :)
  -- further details - the issue happens only when run from debugger
- right click - recreating the context menu each time is very expensive - lets have one with most items hidden and reuse that
  - ToolStripSeparator -> ToolStripMenuItem("-")
    - optimize for what we have -> 20 items children of root + each one have 4 children of its own, AddRange


1.2.19e
- small fix: no view menu for full-log


1.2.19d
- handling all right clicks
- handle "right click via MENU key" - showing the meu where it should be (at the caret)


1.2.19c
- skeleton part 2 - menu is shown 100% correctly 
  - nothing happens when clicking an action (of course :))


1.2.19b
- skeleton part 2 - menu is shown, not 100% correctly


1.2.19a
- skeleton for right click on logview


1.2.18
- tested that list_cellclick is only triggered on click, not right-click


1.2.17d
- msg details -> if i can fit on the low part, do it
- fix: sometimes it showed msg details when not needed (different font)


1.2.17c
- handle logwizard: activate (alt-tab + alttab back)


1.2.17b
- filter - special case - when all filters turned off?


1.2.17a
done:
- retest : modifying matchcolor with eyedropper


1.2.16
- bacskpace -> if i type something and it takes me a few lines above/below, when typing backspace, it should take me BACK. to the EXACT COLUMN/ROW


1.2.15
- settings: above/below/ all columns


1.2.14e
- the current line - msg details -> match all colors 
  THIS IS SO AWESOME, I DON'T HAVE WORDS FOR IT :D


1.2.14d
- the current line (the text box) -> everything that is normally applied (color, match colors) -> apply it to current line


1.2.14c
- refactoring (part 2): move code dealing with colors into log_view_item_draw_ui, so I can reuse it for smart-edit


1.2.14b
- refactoring (part 1): move code dealing with colors into log_view_item_draw_ui, so I can reuse it for smart-edit


1.2.14a
- smart: modified setting sel_col_, so that we update text based on sel_col/sel_row, not on Text itself
         it's because i could have two consecutive lines having the column at sel_col have the same text, but different color
		 I want the colors to be shown correctly (thus, sel_col/sel_row)


1.2.13e
- escape: if editmode != always -> escape edit mode and make edit box invisible


1.2.13d
- fix: log view background - not updated correctly when losing focus
- smart: make visible only after setting location (avoid flicker)
- fix: bug: if on full ctrl/edit if i press a hotkey, it's taken twice (like, Alt-F)


1.2.13c
fixed:
- always should be on edit mode!  
- logwizard - home takes me home but not in edit mode?
  - this does not work correctly 100% of the time (i think when i'm on a different page than the first one)


1.2.13b
- initial start -> we get focus correctly


1.2.13a
- log_wizard : removed postFocus 
- still sometimes it does not focus to smart edit (like, home/end/beginning of app)


1.2.12
- fix: bug: f3 does not always work on the current selection


1.2.11
- fix: bug: escape does not clear the search


1.2.10b
- look again at all keys (esc/bksp/etc) in logwizard -> they showuld work corectly


1.2.10a
- fix: logwizard - up/down -> don't clear the selection'


1.2.9
- escape hotkey - in logview
  if selection -> erase it
  if find colors -> erase it
  if details shown -> erase it
  etc.


1.2.8
- ctrl-f -> if there's something selected, just have that text entered by default (ctrl-shift-f should do that implicitly)
  - HANDLE ALL in log_view - so that log_wizard does not need to know about anything happening in logview
    so that we can easily handle f3/shift-f3 even with what i want
- f3/shift-f3 -> if i have something selected (see above), i should take that into account and search that selected-text forward/backward
  (it would override a ctrl-f; the ctrl-f will be in effect when there's no selection)
  + care about whether focus is in filters-pane /filtersctrl


1.2.7b
- ctrl-f -> if there's something selected, just have that text entered by default (ctrl-shift-f should do that implicitly)
- say i type something, and then it finds all the lines that match what i typed
  - if i go down/up/etc (thus, the selection would be empty -> i should preserve my "find" so that by default those words are still shown in selection-color)
    (until i press escape)


1.2.7a
- ctrl-shift-f works


1.2.6g
- match_color -> here, for a line, i need to run all filters that have matchcolor (since some could actually modify match_color)
  at this time, assume match_color is only for $msg
- fix: in filter_ctrl - right-click menu did not work


1.2.6f
- find regexes work


1.2.6e
- find: instead of marking lines, mark the words directly


1.2.6d
- at this point, selected text by the user is shown correctly


1.2.6c
does not fully work yet:
- what is selected -> show darker in everything that is rendered
- we should also take into account the results of the existing find (and those results take precedence - if any collitions)


1.2.6b
- no more beep on pressing letters
  - still beeps on backspace


1.2.6a
- solved minor bugs 


1.2.5r
- click on a word - if user doesn't leave that place for a while (like, 750ms), we should mark that word!


1.2.5p
- search ahead now works, even with richtext's bug


1.2.5o
- search ahead (the next 100 rows - on the same column)
  - this works, but it's really weird: after a while, everything will be selected - i "love" this richtextbox


1.2.5n
- fix: small bug - on_edit_sel_changed sometimes not called


1.2.5m
- if pressing a char and we're at the end of a word, automatically add space
  - first, search for char appended to text - if nothing found, but adding ' ' and the char finds something, go there
- type space in middle of word + no selection -> select that word
- esc - clear selection
- bksp - one char before (if space last char, delete that too)


1.2.5l
- fix: the selection of edit box a bit darker : now selection is correct (sel_start_ + sel_end_) 
  + can select in both directions (used to be able to work only to the right)


1.2.5k
- the selection of the edit box - make it a bit darker than what already shown
- using richtextbox now


1.2.5j
- smart text box: handles scrolling (from the scroll bar)
- alt->arrow - works


1.2.5h
- using SPACE instead of F2 (f2 already used in bookmars)


1.2.5g
- tested edit mode:
	Always - We're always in Edit mode. Cursor is always visible
	With F2 - Use F2 to toggle Edit mode ON/OFF
	With Right Arrow - turn the Edit mode ON. Move to another line, and it will be turned OFF
- IMPORTANT:
  when in edit mode, ctrl->arrows does not work

- in lw application : f2 does NOT work


1.2.5e
- navigation keys work - all of them (arrows/pgup/pgdown/home/end)
 - special cases: home/end - if at home (selectionstart=0) -> go home (first item)
                           -if at end (selectionstart=endofline) -> go end (last line)


1.2.5d
- several fixes when handling navigation keys
- bug: if for a cell my selection start is bigger than len + i navigate to that cell +  press left-arrow:
  it will navigate to cell on its left, instead of going one char to left.


1.2.5c
- fix: todo: handle click -> go directly to letter on click


1.2.5b
- handle clicking on a cell
- handle background + foreground of the smart edit


1.2.5a
- handling navigation keys in log_view - so that i update the smart edit box.


1.2.4b
- removed keys_debug - added by mistake


1.2.4
- moved log_view into lw_common, so I can easily test it


1.2.3
- updated logwizardsetupsample
- generated new public release


1.2.1
- before updating main article on codeproject


1.1.25
- logSyntaxCtrl - made read-only. It will always point to the syntax we've found for the current log, and the user can't change that.
  - if the user sets a certain syntax, it will be applied to *the whole context*.
    The idea is that it doesn't make any sense to have two different files from the same context have different syntax.
	Even if theoretically that would happen, you can still have an extra choice: file-to-syntax. You'll just add an entry that 
	finds the syntax based on something found in the file header.
done:
- on new file (that does not match any context)
  - we will create a context matching the name of the file (if one exists, we will automatically select it)
  - by default, we'll never go to the "Default" context
  - the idea is for the uesr not to have to mistakenly delete a context when he's selecting a different type of file,
    (since he would want new filters). thus, just create a new context where he can do anything
  - contexts - case-insensitive (when file -> context)
  - syntax: if current context does not have any, use the one the user has set for this log
- syntax: when changed -> refresh everything (even syntax!)
- test syntax : "Use it" -> if the context did not have a default syntax(= invalid syntax) -> use it also
- at app start - delete empty contexts


1.1.24b
- added small article on github about syntax


1.1.24a
- syntax: allow testing 
  - take from existing file
  - if default syntax -> show in red + show the "sourrce pane" + show error in status pane


1.1.23
- finally, managed to supress ctrl-tab/ctrl-shift-tab (so that we use ctrl-leftarrow/ctrl-rightarrow to navigate amongst tabs)
  - probably i could have used ProcessCmdKey all along
    anyway, I will probably keep ctrl-tab/ctrl-shift-tab for navigating between existing logs (in case the user has several logs open)
- allow resizing left pane (and auto-save it)


1.1.22
- bug: render: when choosing background and item not selected -> if bg != white -> use that (test with marking some lines as bookmarks)


1.1.21
- suspend/resume layout - so that thee's no bad flickering
- fix: bug: on release settings -> the left pane is shown too low (very likely - if shown from the beginning)
- removed load_location - we don't need it anymore
- fix: bug: logsetupsameple -> after shown after setup, next time, it's still shown (the former log should be shown on re-run)



1.1.20
- copy to clipboard - html also
  - write status -"text copied to clipoard, as text and html"
- small bug: when enforcing the selection (select_idx) - if i'm on the last visible line - i should actually bring it to middle (since last visible line usually means partially visible)
  (not tested)


1.1.19d
- fix: bug: real time monitoring does not scroll to end
- change ctrl-c / ctrl-shift-c (should be the other way around)


1.1.19c
- got fixed: bug - drag drop new file (first time) - full log shows empty?
- filter: ctrl-enter would save
- updated rewrite app to test with lines


1.1.19b
- fix: if a view that is not the first view was selected, it would show all log (first time)
- creating new filter (+) - new / copy


1.1.19a
- moved load/save of contexts inside the log_wizard_serializable_classes file



1.1.18c
- before several fixes


1.1.18b
- renaming filter - the name text box is too big - overrides +/-/etc. buttons
  - make sure the dark bg is not visible, when renaming filter (put light-colored panel below)
tested
- bug: sometimes filter is not saved when exiting curFilter
  - i don't think i get notified when edit control loses focus which fucks things up'
    - i think the issue happens only when i navigate with tab
	- also, when the column is not selected, curFilter should be disabled
  [NOTE] I think i saved this, but need to properly retest


1.1.18a
- todo: retest creating a new filter (copy of existing) - does not seem to work correctly
 - (creating a new filter) sometimes it shows pretty much nothing - works quite badly


1.1.17
- added possibility to copy to clipboard as html as well


1.1.16
- fix: unnecessary refresh of views
- bug - clicking on a line in a view -> need to update notes line
- bug - interpret up/down etc. keys correctly on notes-crtl (now they move through the current view)
- bug - typing in notes list flickers the full-log (even when pressing Alt key????) - perhaps from my keydown/up handlers???????
- bug - when the view changes -> udpate notes
- bug - sometimes we don't draw correctly - it seems to happen especially if I click another tab with the mouse
- default: don't use gradient


1.1.14
- option to toggle hotkeys off
- context matches -> in settings dialog (easy, for now)
- syntax matches -> in settings dialog (easy, for now)
 


1.1.13c
- created toggles wiki page
  - extra menu : What's this - goes to toggles wiki page


1.1.13b
- toggles menu works
- right-clicking the bug to show the toggles menu works


1.1.13a
- toggles menu works


1.1.12
- history: now show friendly names
- history: for imported/zip files, I show the friendly name


1.1.11
- drop zip files: works
- shift-drop zip files: works


1.1.10
- looked at the competition again. all I can say is LOL
- dropping zip files seems to work correctly; need more testing


1.1.9
- saving to html works like a charm (test_export)
- saving notes to .txt and .html
- saving current view to .txt and .html - works


1.1.8
- opening .logwizard files works as expected (even if double clicked in Windows Explorer)


1.1.7
- passing arg to another logwizard instance
  - SEEMS TO WORK, but the order in COPYDATASTRUCT is wrong


1.1.5f
- merging notes: now works seamlessly
- if has merged notes -> go to notes


1.1.5e
- forced context:
  if i manually change the context for a file, we'll always use that! (forced_file_to_context_)
Done:
- import (import_notes):
  _notes.txt -> merge - if don't find the local notes -> dump an error msg
  _context.txt - parse
    - if new context name + it also contains a log file, import and use
	- if context exists, or there is no file, ignore (means i already have the file locally)
  log-file
    - if i have it locally, i don't care
	- if i don't have it locally, add it to some "local_dir\imported" location and keep it there (preserve the name)


1.1.5d
- import (import_notes):
  importing works, but it does not care about context and friendly names yet
- showing status: if error, show it even if it was hidden
- showing status: show visually that it's an error


1.1.5c
- md5-fast - don't include file name
- on new log file -> reload notes
- allow toggling notes (show_note) alt-n
- clicking the eyedropper - works
- ctrl-c / shift-ctrl-c -> if in edit box, we should not do anything
- todo: tab/shift-tab - care about the notes ctrl (if only cur note selected -> ignore notesctrl)
- associate with .zip and .logwizard extensions 

done:
- export (alt-e) + "Export" button -> export 2 files TOTHINK what to put there:
  (long)
  _notes.txt
  _context.txt - the current context: first line - context name, remaining: (as if copied to clipboard)
  the-log-itself
  (short)
  _notes.txt
  _context.txt - the current context: first line - context name, remaining: (as if copied to clipboard)
  --> create a temp dir, create the two zip files, then remove temp dir
  open it in explorer, select the (long) one



1.1.5b
- md5 - fast -> include file name+size
- now we can get from a file to its notes (no matter what the md5 method, or where the file is from (if not local, that is))
- in settings: disabled "By File Name" - it's pretty dangerous to use, and until I document it better, I don't want people to use it


1.1.5a
- md5 - computing md5 : fast/slow/by file name - they all work correctly


1.1.4
- small improvements on the colors


1.1.3v
- show merged lines with different background - works
- coloring of notes: works (still todo - clicking no eyedropper)


1.1.3t
- merging: works AWESOMELY

DONE:
- (note_user_ctrl) notes: author (in Settings) - by default, username
  - show the author username when toggled into notes + specify a color for author (by default, blue)
    - when showing the other authors, if an author name's color colides with ours, make sure we use something unique (even if several collisions)
  - allow deleting/UNdeleting notes, even from others (basically, we will HIDE it; hidden notes, if shown, show in ligthtgray) 
    - have a checkbox - show Hidden Notes (by default, unchecked)
  - render: the author, bold -> in author's color , the text in the color wanted by the author
  - when typing a note: first line ( # color) - can specify the color (to make it simpler)
- notes: 
  - allow of editing the notes you're creating
  - selecting a note: if mine -> i edit. if another one's, i'm replying
- allow notes - on any line even if bookmark or not
  - clicking on a note - will take you there - notes are prefixed by username (by default, its the windows username)
  - several people can comment on a line
  - clicking on a note: 
    - see if i have the view where the note was made, and if i have the line. if so, i will go there, in that view (since i may be using my own context)
	- otherwise, go to first view where the note is found, if not found anywhere, open full log and go there
  - notes should be abe to have colors (like - green OK, red BAD, gray ACCEPTED, stuff like that)
    - note color != author color!


1.1.3s
- merge - notes for lines that don't have any notes from me are appended to the end
          (that should not happen)


1.1.3r
- fix: allow editing your own notes
- test: replying works awesome (small fixes)


1.1.3p
- retested deleting: works
- tested with notes from 3 people - works (except for replying; replying not tested)
- fixes (worked on 1.1.3o):
  - show/hide deleted notes
  - colors and such


1.1.3o
- fix: bug: clicking outside the notes control on a line would gray out all notes


1.1.3n
- fix: bug: when on a valid note from me, instead of "Edit note" i see "Reply to..."



1.1.3m
- author colors: compute them - care only about the current author's color; the rest - select from predefined list


1.1.3k
- author colors we have unique colors for each author, even if they clash


1.1.3j
- set color fg/bg, updated font - looks pretty awesome


1.1.3i
- solved some bugs: adding works correctly now, and tested delete - seems to work
- "Show Deleted Notes" - note fully tested


1.1.3h
- using GUIDs for line_id/note_id - so that merging will be extremely easy


1.1.3g
- before converting line_id/note_id to GUIDs


1.1.3f
- deleting notes - works (when "show deleted notes disabled")


1.1.3e
- BEFORE: new idea for deleting notes - mark the note(s) as deleted, then recreate the UI


1.1.3d
- load/save works
- synchronizing note to views / views to note works
- saving done correctly (sorted by line)


1.1.3c
- note_ctrl - more testing/bug fixing


1.1.3b
- small note_ctrl improvements - add_note tested a bit


1.1.3a
- small note_ctrl improvements - NOT tested


1.1.2
- made it easy to test the filter_ctrl in test_ui, solved minor bugs
  - still need to retest starting a context from scratch (TN2ScrapeFind)


1.1.0
- work on notes_ctrl (not finished)
- add new context for TN2


1.0.92
- made and tested setup kit


1.0.91h
- moving filter_ctrl into lw_common - step 4 (fully done and tested)
- done:  test that we're always synchronized currnetview-filter_ctrl (on tab change -> update filter_ctrl)
- refreshing color from a filter (with eyedropper) -> instant update


1.0.91g
- compiles - need to properly set the filter_ctrl delegates


1.0.91f DOES NOT COMPILE
- BEFORE filter_ctrl have filter_item point directly to ui_view

- moving filter_ctrl into lw_common - step 3
- done: to erase 
  private void focusOnFilterCtrl_Tick(object sender, EventArgs e) {



1.0.91e
- moving filter_ctrl into lw_common - step 2
  (solved font bug)


1.0.91d
- moving filter_ctrl into lw_common - step 1


1.0.91c
- refactoring: names in lw_common should be in lw_common namespace


1.0.91b
- refactoring - moved some UI code into lw_common
  rationale: I want to be able to test parts of the UI separately (like, the control I'm about to do: notes_ctrl)


1.0.91a
- sheletron (filter_ctrl on test_ui)


1.0.90
- added notes ctrl (scheletron)


1.0.89
- notes: author name, initials + color ->  in settings
  - the author has 2 names - the name + a short name, since we will be showing his shot name in discussions (by default, it's he user's initials -> we compute them as he's changing his name)
- zip extensions -> in settings
- cool color selector in filter - it updates the correct line (if another color was selected) or adds a new line with the color



1.0.88
- https://github.com/jtorjo/logwizard/wiki/Filters
- added color picker (http://www.codeproject.com/Articles/21965/Color-Picker-with-Color-Wheel-and-Eye-Dropper)
- settings -> general / color / Imp/Exp (+ Reset button) / notes
- no more need for update_line_highlight_color



1.0.87
- custom renderer - right now, we can draw custom words/phrases/etc. with different fonts, bold, etc. (list_view_render)
  we need to make it so that we can match anything a filter or a find matches


1.0.86
- added + tested sharpzip - ****awesome lib****


1.0.85
- side effect, of course, everything is smoother, and loads faster, since we don't need to reload matches on the main thread
  (they are loaded in the filter' tread)

- decrease memory footprint - step 11
	- log_view: remove usages of list.GetItemCount()
	- log_view: remove usages of GetItem() - always check for null
	- fix the "needs to scroll to last"


- another possible memory optimization for large files (for much later, probably)
  - load the file in chunks. for each chunk, parse the lines, and then run ALL the filters on that specific chunk of lines
    load another chunk, parse lines, run all filters, and so on.
	this way, we keep very little in large_string (except for line indexes)
	then, when specific lines are asked (for display) - load them from HDD, with some simple caching mechanism
	possible problem - if file is not Unicode-16 or Ascii, we need to match the line index to a specific position in the file
	                   this will probably mean a totatly new large_string class, that would internally keep bytes
					   also in text_file_reader -> in that case, we could pass to large_string -> the bytes themselves (with encoding as well)
  - having said that, this would probably be useful only on 3-4GB+ files (since those could indeed take a lot of memory)
    - for such large files, i may even add an option: pause/resume loading


1.0.84c
- log_view and filter share the matches list
  - on the 90Mb file /64bit - improvement - takes 915-920Mb, used to take aprox 1Gb, so improvent of about 9%
  - on the 280Mb file/64bit - improvement - takes 2340Mb instead of aprox 2750Mb, so improvement of about 15%


1.0.84a
- removed filter.match_indexes_


1.0.83e
- update hotkeys page (mayber online?)- explain toggles in document - so that I can send to Denise.
  - yes, made help page online


1.0.83d
- msg only -> show the line + msg (at this time, i only show msg)
  - save it for EACH view + full log
  - full log: should toggle between line+msg / line+view+msg / everything


1.0.83c
- keeping the ui_info in the context itself seems to make no sense - it quite complicates things - we already keep the position info outside (default_ui_, context_ui_)


1.0.83b
- ' ' toggle between enabled/dimmed in the filter (if on a filter row)
- + - <-V-> etc - buttons should override the header (if the header is visible!)
  - small bug: if both header and views are hidden, the buttons are placed wrongly


1.0.83a
- optimization: filter -> when a filter row is modified / added / or deleted -> I should check exactly that -> so that when updating rows -> reuse what has not been modified
  - bug: move up/down -> sometimes it does not update the "Found" column - also, sometimes it's not updated at all (we should care when filter moved up/down/top/bottom)
    (whe should i recompute "Found" column?)
- if editing a filter row, don't update the filter until the user has gone away from it
- home/end/esc/' '/enter - should work correctly when history dropdown shown
- history dropdown: closing the dropdown -> move focus away from history
  - if title hidden - show it partially
      - ctrl-h -> should show history - if the title is toggled off, just bring the history part to visibility, and then hide it back
  tested, actually, I don't need to show it - dropping teh Dropdown will show all the items in the history, which is exactly what we want.


1.0.82
- udated saving/toggling positions - made MUCH EASIER
  
- Saving/Toggling positions
	  the "position" now encompases: 
	  - application position + size
	  - whether app was maximized or not
	  - last selected view
	  - last selected row
	  - full log splitter position
	  - all toggles

  By default, you're in the "Default" position (you can also call it, position zero). Anything you do is automatically saved.
  At any time, you can switch to another to another position (1 to 5).
  To switch to another position, press Ctrl-1 to Ctrl-5. 
  To switch back to the default position (position zero), just press the hotkey again.

  When going to position 1-5:
  - if you're going there for the first time, the existing position is copied. This works even if
    you're in another position. 
	So, if you're going to position 2, and you were in the default position, the default position is copied into position 2.
	If you're going into position 2 from position 1, the position 1 is copied into position 2.

	From there on, anything you do is saved within this position.
	To go back to the default position, just press the Ctrl-(1 to 5) hotkey again.



1.0.81
- Saving/Toggling positions (+ toggles)
  the "position" now encompases: 
  - application position + size
  - whether app was maximized or not
  - last selected view
  - last selected row
  - full log splitter position
  - all toggles

  Ctrl-Shift-1 to Ctrl-Shift-5 
  - saves the position
  
  Ctrl-1 to Ctrl-5 
  - toggles the position (from the default position to a customly-saved position and back)
  - you can also toggle from one customly-saved position to another customly saved position
  - whenyou are in a Customly-saved position, any change you make to the position is ignored
    (so if you're in position 3 and toggle Title OFF, next time you will toggle to position 3, the Title will be ON;
	 if you make some changes to the position, and want them to update, just re-save the position; 
	 in our case, you would just re-press Ctrl-Shift-3)

  Ctrl-Shift-0
  - marks the current position as the "Default" (which you can automatically tweak further)

  Ctrl-0
  - goes to the position saved by Ctrl-Shift-0
  - remains in "Default" position (does not go into a "Custom" position)
    what this means, is that any changes you make further on, are saved as the "Default" position.



1.0.80j
- fix: small bug: if switch from one custom location to another custom location, it does not work correctly


1.0.80i
- done:  what if on a custom location , changed something and want to resave
- small bug: if switch from one custom location to another custom location, it does not work correctly


1.0.80h
- everything saved correctly - toggling to/from different locations works correctly
- still todo:  what if on a custom location , changed something and want to resave 


1.0.80g
- still bug when hiding tabs and title


1.0.80f
- select line - saved + restored correctly


1.0.80e
- selected view - saved correctly


1.0.80d
- position + maximized + full-log-splitter-distance - saved correctly


1.0.80c
- Esc - if message details is shown - hide it
- refactored the UI-toggles code, to allow for sets of locations/sizes/toggles - NOT complete


1.0.80b
- find - case-insensitive + full words + regex (by default, auto-detect -> [],(),any\ -> regex)
- new default: synchronize colors - with all


1.0.80a
- changed toggle hotkeys - so that they are not single chars (without modifiers like Alt/Ctrl/Shift)
  - due to feedback: the user should not by mistake press a key while in LogWizard and not understand what happens (i.e., freak out)
  - former hotkeys now are Alt-[former_hotkey]; example : toggle filter - Alt-F
- show/toggle status: works (Alt-S)
  - new hotkey for toggling source pane (Alt-O)
- status: just show the file + length, just to show something there, for now
- alt-'s' - toggle status (info about the file/current view - like, file size, number of lines, how many lines the last Find matched; when loading a file -> write status about it)
  - setting a status - either for a number of seconds (after we we get to the previous one), or indefinitely (clears previous queue)
  - what about source pane? what hotkey for it - - alt-o


1.0.79
- allow selecting several rows
- allow resetting the default settings (for Denise)


1.0.77
- toggle 'v' - show/hide view + 'h' show/hide header
  - global - they apply to all views
- show_full_log() -> split into two things -> show_full_log / show_current_view (both can't be off at the same time)
- all toggles are saved into current context (except "show msgonly")
- fix bug: toggle full log -> when pressed ('l') in full-log, it's pressed twice
- history - deleted files - ignore them
- synchronizing with full-log/other logs -> if key is down (up/down/etc.) -> don't sync yet TOTHINK (basically so that we only synchronize when the user has selected the final row)


1.0.76h
- after generated 32 and 64 setup kits

- Decrease memory - final step TODO:
  - log_view has an array of items (_model), which basically are on top of matches_
    I guess we can actually get rid of log_view.item, and embody it match_ - I do have to think about it big time
	I should also think about the fact that I may want to toggle the results of a view + search-in-view (but that should be fine,
	I would just go through the original filter, and do my search, create a copy of the array, with the search; now that i think about it,
	i could even keep another array with the results of a search - if no search, just an empty array; this should also work for when selecting a filter -> which would show the
	results of that filter; at this point - I can easily find out the number of matches to hold)
  - match_indexes_ -> the only time I actually use this is when adding an addition via BinarySearch
    - since i already have binary_search myself, I should look into that 
	  (also - my search returns the closest item; i should see if that is the right place to do an Insert).


1.0.76g
- decrease memory footprint - step 10

- full log : matches computed on the fly (instead of an extra array, which also meant huge delays when we changed the current view)
- full log : computing synchronized colors on the fly - much faster, and using less memory
- one last run of dotmemory - all that is found is ok - no point in sacrificing stuff for more memory increases

- Conclusion at this point:
  - at some point I said that 32-bit occupied mem is about the same as 64-bit. I was wrong (see 1.0.76e)
  - x64 version will take about 40% more memory (due to 8-byte pointers)
  - due to memory improvements, I also got some speed improvements
  - 280Mb file loads only on 64-bit - it takes about 2.5Gb of RAM (with full log shown); note: it has 3M lines
  - 280Mb raises exception on 32-bit (out of memory)
  - 90Mb file takes <600Mb on 32-bit . This is HUGE improvement (initially, it took close to twice as much)
  - I really see no more possible improvements at this point without sacrificing something else (very likely, speed and simplicity)
  **** note: the reason the 280Mb and 90Mb files take so much memory is because many of the lines match in a quite a few filters,
       and I had a LOT of views;
       thus, we end up creating a lot of objects. It's very likely that on some of your huge files that won't be the case, and
	   loading a file of this size would take much less memory and cpu


1.0.76f
- the 280Mb file loads in 2.53Gb of RAM

1.0.76e
- apparently, my Release64's actual platform was x86 instead of x64


1.0.76d
- decrease memory footprint - step 9
  - read full log first - apparent 10% less memory consumed (on 90Mb file)


1.0.76c
- decrease memory footprint - step 8
  - done all I said in 1.0.75
  - note: basically the memory itself did not drop by much, ***however***, I did minimize the posibility of an out-of-memory exception 
    due to memory fragmenting


1.0.76b
- fix bug at filter.add_addition_line (not tested)


1.0.76a
- decrease memory footprint - step 7
  - added memory_optimized_list
  - BEFORE making 'filter' - matches member into a list (instead of dictionary)


1.0.75
- decrease memory footprint - step 6
  - removed gcConcurrent="false" (http://stackoverflow.com/questions/1267611/net-is-there-a-way-to-change-the-gc-behavior-for-the-entire-machine)
  - allow creating huge objects on x64 (http://www.centerspace.net/blog/large-matrices-and-vectors/)
  - added gcServer enabled="true" (http://content.atalasoft.com/h/i/58213870-choosing-the-right-garbage-collector-settings-for-your-application-net-memory-management-part-4)

- tried loading the full log first, then refreshing filters, this made things worse (filter.compute_matches_impl) - crash even with full log off

- notes: 
  - on 280 Mb file, I still got outofmemory exception when showing full log
  - perhaps a system restart could help
  - since i've updated the above (in app.config), we crash on the huge file

******** possible further improvements
   -stringbuilder -> set its capacity (since we know the size of the original file)
     - also, force a gc.collect level 3 ?
   http://blogs.msdn.com/b/vsofficedeveloper/archive/2008/10/10/stringbuilder-outofmemoryexception.aspx
   - full log -> set capacity of _model to the number of lines
   - have a connection pool of List<T>. then, when items are added, ensure we have the space for them, and we reuse them constantly
     - have a minsize for the number of items (at which, this should start happening)
	 - i should use this on all List<list_view.item> and filter.match?


1.0.74c
- decrease memory footprint - step 5
 - loaded 90Mb file , takes 640Mb instead of 1084Mb (1.0.66) = when showing full log
 - loads 280 Mb file - takes 1170Mb when not showing full log; when full log is shown, it crashes (outofmemoryexception)

******** possible furher improvements: 
  - some of the objects could be created on the stack - like: 
    - log_line_parser.read_to_line (List<line> now)
	- filter.compute_matches_impl (new_matches, new_match_indexes)
	  - here, I could tweak with .Capacity ?
	- log_view.update_view_column (matches)
	- maybe 'match' could be made a struct? careful - not sure if i assume it's pased by value - however, this should be immutable
	  - note : this might actualy backfire, because there are plenty of places holding a match
  - large_string -> indexes_ -> maybe enlarge its capacity as we add new lines? 
    (like, 20% or so - only when needed; have a ratio of: number of lines / existing-string -> thus, get the average line length;
	 then, based on that, we should see if we need to increase indexes_' capacity )
  - filter - matches_ dictionary could become a list - not sure if this would yield that much of an improvement though

  - another possibly big improvement: the line should not keep a reference to the large_string
    - every request for a part of a line would need to send the large_string reference as well
	- this can also backfire, because in list_view.item, we would need to keep a reference to either the large_string, or the parent
	  so very likely no gain would be achieved
	  - the more I think about, the more I think this would bring unnecessary complexity, with very small gains, if any
	    (like, if we move the ref to large_string from line into filter.match, we will end up having more references to large_string,
		 since we can have more matches than lines - if several filters match the lines -> so, not a good idea)


1.0.74b
- decrease memory footprint - step 4 
  - using BitArray instead of bool[]
  - further testing
  - fixed bug from 1.0.74a - works as expected now

Notes:
- I initially thought that compiling as 32-bit would save us quite a lot of memory - this does not seem to be the case.
- memory "bottlenecks" are:
  - line class - not much can be improved about it
  - filter.match - probably a small improvement could be achieved by making filter_line.font_info a struct - however, i don't think it's worth my time at this point
  - *** log_view.item 
    - i could create a class derived from item, for the full-log only -> which would keep the parent_ and matched_logs (note: done: in 1.0.74c)


1.0.74a
- decrease memory footprint - step 3 - large_string now holds the whole string, and the lines point into it
  - rationale: dotmemory found a LOT of small strings
  - IMPORTANT: there is a BUG - at huge files, some lines are missed (huge1.txt - we miss two lines)
    (very likely, we consider they are part of existing lines and append to them)
	also, it's likely that I access some lines before they are fully read (like, a line was partially read) - and i don't treat that correctly

- managed to successfully load 280Mb file - we occupy about 1.1Gb - which is quite decent (older version just crashed)


1.0.73
- decrease memory footprint - step 2 (loaded 90Mb file , takes 515Mb instead of 811Mb (1.0.66))

1.0.72b
- decrease memory footprint - step 1


1.0.72a
- toggling full log -> make sure we focus on a view, so that we don't end up having focus on a hidden control
  - bug: toggle full log -> when pressed ('l') in full-log, it's pressed twice
         note : this did not exist on 1.0.71


1.0.71b
- updated setup kit so that some HM3 log views are there by default


1.0.71
- fix: deal with big files (_test1.HoldemManager.Import.test.txt) -> do profiling
  synchronizing with other views - use binary search


1.0.70b
- deal with homogeneous logs (hm3 files -> several syntaxes)


1.0.70a
- synchronize colors : full log - synchronize with what the existing tab has and/or with all tabs? 
  (Sync: with current tab / with all tabs / none)


1.0.69
- fix - drop one file onto logwizard; then drop another -> press ctrl-f -> the find window is shown behind our window (our window was made topmost somehow?)
  as soon as i drop something -> our window becomes topmost?


1.0.69a
- apply to existing lines
- when changing tab (view) -> we update the filterctrl - we also need to clear curFilterText + applytoexistingfilters


1.0.68
- fix: bug - full log no longer rightly synchronized with current view


1.0.67
- fix: "refresh" -> should clear the existing filter's cache -> so that it updates
  test: go from '\breading\b' 
	-> remove the case-sensitive, then refresh
	-> add it back, then refresh
- added Open in Explorer command (Ctrl-O)
- open with LogWizard - for .log and .txt files
- send to logwizard - for ay file
- fix: on file rewrite (bring to top on restart) 
  -> make sure to navigate to last line!
- fix: on file rewrite (bring to top on restart) 
  -> done: see if i can bring to top+topmost without gaining focus
- help/goto/find/etc - all other forms - if parent is topmost, make topmost as well (othewise they would be covered by parent)


1.0.66
- filters now can match regexes as well. in fact, by default, they work as regexes. If you say:
  $[part-of-line] some-regex-expression, it works as regex.
  Example:
  $msg \breading\b
  - will match all lines containing the word 'reading'
- settings file - save settings in such a way that I can add regexes (namely, don't escape multiple lines the way i used to)
- filter friendly names -> just add a line (anywhere) thta starts with '## ' 
- show the filter in background pink if it's an invalid one
- when you edit the filter, and set the color ('color XXX' line), it will visually show the color


1.0.65
- made logwizard run as invoker again (rationale: now, that i made logwizard run as admin, i can't drop files onto it)
  tested: "bring to top on restart" works as expected


1.0.64
- support non-ascii encodings
- adjust time of lines that could not be parsed
- allow time that uses : as millis separator
- auto recognized msi log files
  - at this time, non homegeneous lines are considered 'just message'
- fix: auto update msg details when toggling
- fix: when filters pane shown, msg details should not override it


1.0.62
- made the icon much smaller


1.0.61
- fix: test on deleted settings file (we used to have problems)


1.0.60
- added application manifest, to request admin credentials -> for topmost to work correctly (still did not work)
- fixed setting topmost - forcing it via win32 messages


1.0.58
- toggle topmost - allow showing even if title is shown as well
- fix: filter buttons not shown properly
- settings by file - easy to have settings by file (bring to top on restart/make topmost no restart)
- bring to top on restart - works as expected, but when another app is full-screen, 
  sometimes TopMost=true is ignored


1.0.57
- toggle topmost works - via button (only when title is not shown)


1.0.56e
- 'T' - toggle title (remove border + lower pane)
- by default -> don't sync views (for large files -> it's slow')


1.0.54
- f5 = refresh
- generate the release build as x64 by default
- whenever something is added - to a view that is not current, show visually (bold) that there are new items there


1.0.52
- go to line/time
  - allow even goodies like +4s and such


1.0.51c
- fix: bug -> sometiems changnig the file stops refresheshing the existing view - probably because of wait_for_filter_to_read_from_new_log_


1.0.51b
- export to clipboard/import from clipboard for filters/full-context
- initial version of settings
- Monitor TN2 - if present (%appdata%\tn2)
- Refresh button - moved next to history


1.0.51a
- filter row: Move to Top / Move To Buttom
- resize log wizard: update message details
- key down - in edit -> don't have it as hotkey


1.0.50
- sync all views to existing view - force all views to go to the closest line 
- show the number of lines in teh tab + show when it changes
  WEIRD BUG: in order for logs to be in sync, i need to go with ctrl-=> to each log. then, they will end up in sync as i change the items


1.0.49
- done, works: check if monitoring the same file - and that file gets rewritten -> everything should go from zero
- updated TableNinja context


1.0.47
- monitoring a file - don't hold _fs internally - so that the other program can write to it
- change icon
- fix: bug when chaning files - now no crash, but some info is not updated


1.0.46
- fix: bug when changing log files 
- tested very big file (280Mb) - works on x64
- msg_details: match the color of the line you're showing details for


1.0.45
- initially added and tested on github


1.0.44
- efficiency : filter is thread-safe
- note: made filter disposable, but at this time we don't need it


1.0.42
- efficiency: reading the log_line_parser / log_line_reader : on their own thread


1.0.41
- efficiency: reading the file on a different thread - doubled the speed (for 32Mb log file)


1.0.40
- working on efficency - small improvement - line.part() does not take a substring of the line


1.0.39
- the last selected item from history -> move to last, so that next time we auto-open it


1.0.38
- made the Filters - into a pane (with several tabs) - I'll allow having several extensions later (like, Allow filtering by thread/context)
- several hotkeys - if focus on edit, they should not work
- allow case-insensitive filters
- allow filtering for "contains any/none"


1.0.37
- clearer UI hints when a certain view becomes active (like, when you within panes with Tab/Shift-tab)
- allow de-synchronizing existing log with full log (until now they were in sync)
- toggle Full Log - allow toggling: view/both/full-log-only


1.0.36
- letter hotkeys - should not work when focus on edit

1.0.35
- +/- hotkeys - increase/decrease font
- m - just the log messages (without the time/etc.) - this applies only to the current view 
(so for instance if full log is present as welll, it would only apply to the current view)
- ctrl-up/down for log, just like it's in notepad++


1.0.34
- setup sample - shown correctly, added SetupSample filters, in order to be shown correctly at setup


1.0.33
- handle showing the setup sample - when running setup
  more importantly, making sure that the setup sample is added to the history, and when shown again, it will care about
  its position in history (by default, we load the last log)
- when setup kit is run, we wait for it to end and then show the setup sample


1.0.28
- tab / shift-tab - work
- up/down arrows - if history dropdown or focus in filters ctrl (filter list/cur filter), do normal behavior
- h - toggle history dropdown (after the dropdown closes, focus back to last known pane)
- ctrl-n - new window
- ctrl-s - settings
- updated help form


1.0.27b
- tooltip - not shown on msg column, the msg_details is shown instead when needed


1.0.27a
- fixed the "tooltip" - made it as control instead of a form (msg_details_ctrl)


1.0.26
- added About form
- added: if current line is too big to show (thus, we would need a tooltip),we can show it as an edit box (or label), behind the line TOTHINK perhaps we would want to turn this off at times?
  show this either at the bottom or at the top (by default, at the bottom)
  HOWEVER It does not FUCKING work. I'm too nervous to investigate - it constantly steals focus from the log wizard - which should NOT happen.


1.0.25
- added Debug64/Release64 configs. Note: on valerie/TableNinja2.log.5 -> it generates on exception on Release64, but no exception on Release
- ctrl-c - copy to clipboard (only the msg) ; ctrl-shift-c - copy full line
- bookmarks work


1.0.24
- extra column on Fulllog -> shows the views where a line was found. Also, updates based on which view is selected


1.0.23d
- selecting a filter -> marks all lines containing that filter + allows doing f3/shift-f3


1.0.23c
- log view made as ownerdrawn, so that i can specify UnfocusedHightlight color
- saving last search (text/bg/fg)


1.0.23b
- ctrl-f/esc/f3/shift-f3 work correctly


1.0.23a
- hotkeys: action hotkeys (up/down/pgup/etc) if full-log is selected, they should apply to it
- fix: - bug: in full-log, control keys are interpreted twice (such as pgup/pgdn etc)
- ctrl-f/Esc work - basically, we override the fg + bg


1.0.22
- initial settings page (shows hotkeys/tips)
- scheletron for finding text


1.0.21
- added GNU v3 licensing


1.0.20
- as the file is appended to, all the filters update correctly (same for the "full log")
fixes:
- apparently - teh full log is not correctly refreshed as more info is written to it (windows 8/10)
- windows 10: apparently we don't update in time as file is refreshed


1.0.19
- Home key works


1.0.18
- tooltip only if text bigger than col width
- Filter "-" - select something after deletion
- refresh button on the filter: done: not fully tested, seems to work though
- font names: by default fixed width
- previewkeydown/up -> allow global hotkeys


1.0.16
- tested log being constantly appended to/rewritten : works now


1.0.15
- added LogWizardSample file
- refactored log_to_default_context/syntax
- recognize Sample file
- recognize TN2 debug files


1.0.14
- initial tests of log being constantly appended to/rewritten work


1.0.13c
- moved file_text_reader code into simple_file_text_reader
- moved log-syntax related code into find_log_syntax


1.0.13b
- file_text_reader -> make sure pos_ is ulong


1.0.13
- added rewritelogfile - to test logwizard as a file gets rewritten


1.0.11
- added version to the title


1.0.10
- update log columns based on whether they are empty or not


1.0.9
- HM2 syntax recognized correctly
- HM3 syntax recognized correctly


1.0.8
- tooltip on view_log line -> show the full line


1.0.7
- setup kit + release mode - keep settings in roaming dir


1.0.6
- allow having the "All" view -> and allow toggling it, and keeping it in sync with active tab.


1.0.5
- implemented additions
- on addition -> gray the original color
- test history (changing files)
- changing the file -> does not automatically update


1.0.4
- remember "toggle" settings
- updated tooltip for "Filter"
- partially implemented additions


1.0.3
- using virtuallist
- refrences to log4net/objectlistview via nuget
- virtuallist works so far


1.0.2
- starting to work - several filters work correctly


1.0.1
- roughtly, UI is ready - need to actually read logs and apply filters
done:
- deleting a mid-view -> need to update all filters! (since they are kept by indexes)
- adding a view -> copy all filters from existing view!
- adding a view -> add it AFTER the existing one (in TabPages)
- adding a view -> select it
