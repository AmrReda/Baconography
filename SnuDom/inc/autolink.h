/*
 * Copyright (c) 2011, Vicent Marti
 *
 * Permission to use, copy, modify, and distribute this software for any
 * purpose with or without fee is hereby granted, provided that the above
 * copyright notice and this permission notice appear in all copies.
 *
 * THE SOFTWARE IS PROVIDED "AS IS" AND THE AUTHOR DISCLAIMS ALL WARRANTIES
 * WITH REGARD TO THIS SOFTWARE INCLUDING ALL IMPLIED WARRANTIES OF
 * MERCHANTABILITY AND FITNESS. IN NO EVENT SHALL THE AUTHOR BE LIABLE FOR
 * ANY SPECIAL, DIRECT, INDIRECT, OR CONSEQUENTIAL DAMAGES OR ANY DAMAGES
 * WHATSOEVER RESULTING FROM LOSS OF USE, DATA OR PROFITS, WHETHER IN AN
 * ACTION OF CONTRACT, NEGLIGENCE OR OTHER TORTIOUS ACTION, ARISING OUT OF
 * OR IN CONNECTION WITH THE USE OR PERFORMANCE OF THIS SOFTWARE.
 */

#ifndef UPSKIRT_AUTOLINK_H
#define UPSKIRT_AUTOLINK_H

#include "buffer.h"

#ifdef __cplusplus
extern "C" {
#endif

enum {
	SD_AUTOLINK_SHORT_DOMAINS = (1 << 0),
};

int
sd_autolink_issafe(const uint8_t *link, size_t link_len);

size_t
sd_autolink__www(void* opaque, void* (*allocate)(void *opaque, size_t size), size_t *rewind_p, struct buf *link,
	uint8_t *data, size_t offset, size_t size, unsigned int flags);

size_t
sd_autolink__email(void* opaque, void* (*allocate)(void *opaque, size_t size), size_t *rewind_p, struct buf *link,
	uint8_t *data, size_t offset, size_t size, unsigned int flags);

size_t
sd_autolink__url(void* opaque, void* (*allocate)(void *opaque, size_t size), size_t *rewind_p, struct buf *link,
	uint8_t *data, size_t offset, size_t size, unsigned int flags);

extern size_t
sd_autolink__subreddit(void* opaque, void* (*allocate)(void *opaque, size_t size), size_t *rewind_p, struct buf *link, uint8_t *data, size_t offset, size_t size);

extern size_t
sd_autolink__username(void* opaque, void* (*allocate)(void *opaque, size_t size), size_t *rewind_p, struct buf *link, uint8_t *data, size_t offset, size_t size);

#ifdef __cplusplus
}
#endif

#endif

/* vim: set filetype=c: */
