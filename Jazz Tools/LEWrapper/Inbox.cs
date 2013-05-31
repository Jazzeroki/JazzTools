using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jayrock.Json;
using Jayrock.Json.Conversion;

namespace LE_Wrapper
{
    partial class LEWrapper
    {
        private string inboxURL = "/inbox";
        /*
         * 
    view_inbox ( session_id, [ options ] )
        session_id
        options
            page_number
            tags 
    view_archived ( session_id, [ options ])
    view_trashed ( session_id, [ options ])
    view_sent ( session_id, [ options ] )
    read_message ( session_id, message_id )
        session_id
        message_id 
    archive_messages ( session_id, message_ids )
        session_id
        message_ids 
    trash_messages ( session_id, message_ids )
        session_id
        message_ids 
    send_message ( session_id, recipients, subject, body, [ options ] )
        session_id
        recipients
        subject
        body
        options
            in_reply_to
            forward 

         * 
         */

    }
}
